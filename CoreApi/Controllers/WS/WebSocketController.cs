using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace CoreApi.Controllers.WS
{
	public class WebSocketController : Controller
	{
		private readonly IConnectionMultiplexer _redisConnection;
		public WebSocketController(IConnectionMultiplexer redisConnection)
		{
			_redisConnection = redisConnection;
		}
	}
}
