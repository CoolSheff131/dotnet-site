namespace BusinessLayer.Interfaces
{
	public interface IDirectoriesRepository
	{
		IEnumerable<DataLayer.Entities.Directory> GetAllDirectories(bool includeMaterials = false);
		DataLayer.Entities.Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
		void SaveDirectory(DataLayer.Entities.Directory achieve);
		void DeleteDirectory(DataLayer.Entities.Directory achieve);
	}
}
