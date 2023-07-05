using AuthorizationServiceDevelopment.Controllers;
using AuthorizationServiceDevelopment.Data;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationServiceDevelopment
{
	public class Startup
	{
		private IConfiguration configuration { get; }

		public Startup(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			string connection = configuration.GetConnectionString("AuthorizationDatabaseConnection");
			services.AddDbContext<AuthorizationDbContext>(options =>
				options.UseSqlServer(connection));
			services.AddDatabaseDeveloperPageExceptionFilter();

			services.AddControllers();

			services.AddTransient<IAuthorizationController, AuthorizationController>();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseEndpoints(endpoints => endpoints.MapControllers());
		}
	}
}
