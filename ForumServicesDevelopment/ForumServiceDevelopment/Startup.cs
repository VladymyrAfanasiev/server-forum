using ForumServiceDevelopment.Data;
using ForumServiceDevelopment.Services;
using Microsoft.EntityFrameworkCore;

namespace ForumServiceDevelopment
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

			services.AddControllers();

			services.AddTransient<IGroupService, GroupService>();
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
