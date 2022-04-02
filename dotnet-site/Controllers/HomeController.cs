using Microsoft.AspNetCore.Mvc;

namespace dotnet_site.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your app";
			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "contact page";
			return View();
		}
	}
}
