using dotnet_site.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_site.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			HelloModel _model = new HelloModel() { HelloMessage = "Hey Alexander!"};
			return View(_model);
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
