using CoreDatabase.Source.Interfaces;
using CoreDatabase.Source.Repository.Tibia;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreDatabase.Source.Configuration
{
	public class Startup
	{
		public readonly IConfiguration _config;
		public Startup(IConfiguration configuration)
		{
			_config = configuration;
		}
		public static void ConfigureServices(IServiceCollection services,IConfiguration configuration)
		{

			services.AddScoped<DbContexto>(_ =>	new DbContexto() );

		}
	}
}
