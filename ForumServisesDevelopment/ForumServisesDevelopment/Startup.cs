using ForumServisesDevelopment.Data;
using Microsoft.EntityFrameworkCore;

namespace ForumServisesDevelopment
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
			string connection = configuration.GetConnectionString("ForumDatabaseConnection");
			services.AddDbContext<ForumDatabaseContext>(options =>
				options.UseSqlServer(connection));
			services.AddDatabaseDeveloperPageExceptionFilter();
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
