using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer;
using PresentationLayer.Models;
using static DataLayer.Enums.PageEnums;

namespace dotnet_site.Controllers
{
	public class PageController : Controller
	{
		private DataManager _dataManager;
		private ServicesManager _serviceManager;
		public PageController(DataManager dataManager)
		{
			_dataManager = dataManager;
			_serviceManager = new ServicesManager(_dataManager);
		}
		public IActionResult Index(int pageId, PageType pageType)
		{
			PageViewModel _viewModel;
			switch (pageType)
			{
				case PageType.Directory: _viewModel = _serviceManager.Directorys.DirectoryDBToViewModelById(pageId); break;
				case PageType.Material: _viewModel = _serviceManager.Materials.MaterialDBModelToView(pageId); break;
				default: _viewModel = null; break;
			}
			ViewBag.PageId = pageType;
			return View(_viewModel);
		}
		public IActionResult PageEditor(int pageId, PageType pageType, int directoryId = 0)
		{
			PageEditModel _editModel;
			switch (pageType)
			{
				case PageType.Directory:
					if (pageId != 0) _editModel = _serviceManager.Directorys.GetDirectoryEditModel(pageId);
					else _editModel = _serviceManager.Directorys.CreateNewDirectoryEditModel();
					break;
				case PageType.Material:
					if (pageId != 0) _editModel = _serviceManager.Materials.GetMaterialEditModel(pageId);
					else _editModel = _serviceManager.Materials.CreateNewMaterialEditModel(directoryId);
					break;
				default: _editModel = null; break;
			}
			ViewBag.PageId = pageType;
			return View(_editModel);
		}

		[HttpPost]
		public IActionResult SaveDirectory(DirectoryEditModel model)
		{
			_serviceManager.Directorys.SaveDirectoryEditModelToDb(model);
			return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Directory });
		}

		[HttpPost]
		public IActionResult SaveMaterial(MaterialEditModel model)
		{
			_serviceManager.Materials.SaveMaterialEditModelToDb(model);
			return RedirectToAction("PageEditor", "Page", new { pageId = model.Id, pageType = PageType.Material });
		}
	}
}
