using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Core.Abstractions;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Newtonsoft;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;
using CoreBusiness.Source.Interface;
using CoreBusiness.Source.Service;
using StackExchange.Redis.Extensions.Core;
using CoreBusiness.Source.Helper;

namespace CoreApi
{
	public class Startup
	{
		public IConfiguration Configuration { get;  }
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			CoreBusiness.Source.Configuration.Startup.ConfigureServices(services, this.Configuration);
			CoreDatabase.Source.Configuration.Startup.ConfigureServices(services, this.Configuration);


			services.AddHealthChecks();
			
			
			ServicesDependencyInjection(services);
			services.AddMvc();
			services.AddSwaggerGen();

			var redisConfiguration = new RedisConfiguration()
			{
				AbortOnConnectFail = false,
				AllowAdmin = true,
				ConnectTimeout = 15000,
				Database = 0,
				Hosts = new RedisHost[] { new RedisHost() { Host = "localhost", Port = 6379 } },
				Ssl = false,
				ConnectRetry = 3,
			};

			services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>(redisConfiguration);


			//services.AddSingleton<IRedisCacheClient>(x => x.GetRequiredService<IRedisCacheConnectionPoolManager>().GetConnection());
			//services.AddSingleton<IRedisCacheConnectionPoolManager, RedisCacheConnectionPoolManager>();

			services.AddControllers();
			


			services.AddCors(options =>
			{
				options.AddPolicy("AllowAll", builder =>
				{
					builder.AllowAnyOrigin()
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				});
			});


		}
		void ServicesDependencyInjection(IServiceCollection services)
		{
			services.AddScoped<IMonsterService, MonsterService>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

		}
		public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			if (env.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			app.UseWebSockets();
			app.UseCors(builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyHeader()
					   .AllowAnyMethod();
			});


			app.Use(async (context, next) =>
			{
				//Console.WriteLine(CommonFunctionsStatic.ConvertObjectToJson(context));
				//Console.WriteLine(CommonFunctionsStatic.ConvertObjectToJson(next));
				if (context.Request.Path == "/ws")
				{
					if (context.WebSockets.IsWebSocketRequest)
					{
						var socket = await context.WebSockets.AcceptWebSocketAsync();
						await HandleWebSocket(socket, context.RequestServices.GetRequiredService<IConnectionMultiplexer>());
					}
					else
					{
						context.Response.StatusCode = 400;
					}
				}
				else
				{
					await next();
				}
			});

		}
		private async Task HandleWebSocket(WebSocket socket, IConnectionMultiplexer redis)
		{
			var channel = "chat";
			var db = redis.GetDatabase();
			var buffer = new byte[1024 * 4];

			while (socket.State == WebSocketState.Open)
			{
				var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), System.Threading.CancellationToken.None);

				if (result.MessageType == WebSocketMessageType.Text && result.EndOfMessage)
				{
					var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
					db.ListRightPush(channel, message); // Armazena a mensagem no Redis

					// Envie a mensagem para todos os clientes conectados
					var subscribers = await db.ListRangeAsync(channel);
					foreach (var subscriber in subscribers)
					{
						if (subscriber.HasValue)
						{
							//var subscriberSocket = new WebSocketWrapper((await subscriber.ToStringAsync()).GetBytes());
							//var subscriberSocket = new WebSocketWrapper(subscriber.ToString().GetBytes());
							//var subscriberSocket = new WebSocketWrapper(Encoding.UTF8.GetBytes(subscriber.ToString()));
							var subscriberSocket = new WebSocketWrapper(socket);

							await subscriberSocket.SendAsync(buffer, WebSocketMessageType.Text, true, System.Threading.CancellationToken.None);
						}
					}
				}
			}

			await socket.CloseAsync(socket.CloseStatus.Value, socket.CloseStatusDescription, System.Threading.CancellationToken.None);
		}
	}
	public class WebSocketWrapper
	{
		private readonly WebSocket _webSocket;

		public WebSocketWrapper(WebSocket webSocket)
		{
			_webSocket = webSocket ?? throw new ArgumentNullException(nameof(webSocket));
		}

		public async Task SendAsync(byte[] buffer, WebSocketMessageType messageType, bool endOfMessage, CancellationToken cancellationToken)
		{
			await _webSocket.SendAsync(new ArraySegment<byte>(buffer), messageType, endOfMessage, cancellationToken);
		}
	}
}
