using APIGatewayServiceDevelopment.Middleware;
using APIGatewayServiceDevelopment.Modules.Configurations;

namespace APIGatewayServiceDevelopment
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
			MicroservicesConfigurations microservicesConfigurations = new MicroservicesConfigurations();
			configuration.Bind("Microservices", microservicesConfigurations);
			services.AddSingleton(microservicesConfigurations);
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseMiddleware<ErrorHandlerMiddleware>();
		}
	}
}
