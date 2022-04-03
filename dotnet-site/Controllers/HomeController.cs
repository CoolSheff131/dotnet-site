using DataLayer;
using dotnet_site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_site.Controllers
{
	public class HomeController : Controller
	{
		private EFDBContext _context;
		public HomeController(EFDBContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			HelloModel _model = new HelloModel() { HelloMessage = "Hey Alexander!"};
			List<DataLayer.Entities.Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();
			return View(_dirs);
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
