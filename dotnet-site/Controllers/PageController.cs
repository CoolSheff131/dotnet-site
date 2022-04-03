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
		public IActionResult PageEditor(int pageId, PageType pageType)
		{
			PageEditModel _editModel;
			switch (pageType)
			{
				case PageType.Directory: _editModel = _serviceManager.Directorys.GetDirectoryEditModel(pageId); break;
				case PageType.Material: _editModel = _serviceManager.Materials.GetMaterialEditModel(pageId); break;
				default: _editModel = null; break;
			}
			ViewBag.PageId = pageType;
			return View(_editModel);
		}
	}
}
