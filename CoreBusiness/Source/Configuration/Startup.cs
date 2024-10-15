
using CoreBusiness.Source.Interface;
using CoreBusiness.Source.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreBusiness.Source.Configuration
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}
		public static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
		{
			services.AddScoped<IMonsterService, MonsterService>();
		}
	}
}
