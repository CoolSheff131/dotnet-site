using BusinessLayer.Interfaces;

namespace BusinessLayer
{
	public class DataManager
	{
		private IDirectoriesRepository _directoriesRepository;
		private IMaterialsRepository _materialsRepository;

		public DataManager(IDirectoriesRepository directoriesRepository, IMaterialsRepository materialsRepository)
		{
			_directoriesRepository = directoriesRepository;
			_materialsRepository = materialsRepository;
		}

		public IDirectoriesRepository Directories { get { return _directoriesRepository; } }
		public IMaterialsRepository Materials { get { return _materialsRepository; } }
	}
}
