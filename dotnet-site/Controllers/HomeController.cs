using BusinessLayer;
using BusinessLayer.Interfaces;
using DataLayer;
using dotnet_site.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_site.Controllers
{
	public class HomeController : Controller
	{
		//private EFDBContext _context;
		//private IDirectoriesRepository _dirRep;
		private DataManager _dataManager;
		public HomeController(/*EFDBContext context, IDirectoriesRepository dirRep,*/ DataManager dataManager)
		{
			//_context = context;
			//_dirRep = dirRep;
			_dataManager = dataManager;
		}
		public IActionResult Index()
		{
			HelloModel _model = new HelloModel() { HelloMessage = "Hey Alexander!"};
			//List<DataLayer.Entities.Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();
			//List<DataLayer.Entities.Directory> _dirs = _dirRep.GetAllDirectories().ToList();
			List<DataLayer.Entities.Directory> _dirs = _dataManager.Directories.GetAllDirectories().ToList();
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
