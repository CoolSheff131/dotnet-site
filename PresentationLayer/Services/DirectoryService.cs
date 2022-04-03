using BusinessLayer;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
	public class DirectoryService
	{
		private DataManager _dataManager;
		private MaterialService _materialService;
		public DirectoryService(DataManager dataManager)
		{
			this._dataManager = dataManager;
			_materialService = new MaterialService(dataManager);
		}

		public List<DirectoryViewModel> GetDirectoriesList()
		{
			var _dirs = _dataManager.Directories.GetAllDirectories();
			List<DirectoryViewModel> _modelsList = new List<DirectoryViewModel>();
			foreach(var item in _dirs)
			{
				_modelsList.Add(DirectoryDBToViewModelById(item.Id));
			}
			return _modelsList;
		}

		public DirectoryViewModel DirectoryDBToViewModelById(int directoryId)
		{
			var _directory = _dataManager.Directories.GetDirectoryById(directoryId, true);

			List<MaterialViewModel> _materialsViewModelList = new List<MaterialViewModel>();
			foreach (var item in _directory.Materials)
			{
				_materialsViewModelList.Add(_materialService.MaterialDBModelToView(item.Id));
			}
			return new DirectoryViewModel() { Directory = _directory, Materials = _materialsViewModelList };
		}

		public DirectoryEditModel GetDirectoryEditModel(int directoryId = 0)
		{
			if(directoryId != 0)
			{
				var _dirDB = _dataManager.Directories.GetDirectoryById(directoryId);
				var _dirEditModel = new DirectoryEditModel()
				{
					Id = _dirDB.Id,
					Title = _dirDB.Title,
					Html = _dirDB.Html
				};
				return _dirEditModel;
			}
			else
			{
				return new DirectoryEditModel() { };
			}
		}

		public DirectoryViewModel SaveDirectoryEditModelToDb(DirectoryEditModel directoryEditModel)
		{
			DataLayer.Entities.Directory _directoryModelDbModel;
			if(directoryEditModel.Id != 0)
			{
				_directoryModelDbModel = _dataManager.Directories.GetDirectoryById(directoryEditModel.Id);
			}
			else
			{
				_directoryModelDbModel = new DataLayer.Entities.Directory();
			}
			_directoryModelDbModel.Title = directoryEditModel.Title;
			_directoryModelDbModel.Html = directoryEditModel.Html;

			_dataManager.Directories.SaveDirectory(_directoryModelDbModel);
			return DirectoryDBToViewModelById(_directoryModelDbModel.Id);
		}
	}
}
