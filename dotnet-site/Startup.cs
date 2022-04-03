using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLayer.Interfaces;
using BusinessLayer.Implementations;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace dotnet_site
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			var connection = Configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<EFDBContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("DataLayer")));

			services.AddTransient<IDirectoriesRepository, EFDirectoriesRepository>();
			services.AddTransient<IMaterialsRepository, EFMaterialsRepository>();

			services.AddScoped<DataManager>();	
			services.AddControllersWithViews()
				.SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0)
				.AddSessionStateTempDataProvider();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			// подключаем поддержку статичных файлов в приложении (css, js и т.д.)
			app.UseStaticFiles();

			// подключаем систему маршрутизации
			app.UseRouting();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					"default",
					"{controller=Home}/{action=Index}/{id?}");
			});

		}
	}
}
