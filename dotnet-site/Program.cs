//var builder = WebApplication.CreateBuilder(args);
//// Add services to the container.
//builder.Services.AddRazorPages();
//var app = builder.Build();
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//	app.UseExceptionHandler("/Error");
//	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//	app.UseHsts();
//}
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseRouting();
//app.UseAuthorization();
//app.MapRazorPages();
//app.Run();

using DataLayer;
using Microsoft.AspNetCore;

namespace dotnet_site 
{ 
	public class Program
	{
		public static void Main(string[] args)
		{
			//BuildWebHost(args).Run();
			var host = CreateHostBuilder(args).Build();

			using(var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;

				var context = services.GetRequiredService<EFDBContext>();
				SampleData.InitData(context);
			}

			host.Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			});
	}
}
