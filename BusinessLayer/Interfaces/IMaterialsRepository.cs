using DataLayer.Entities;

namespace BusinessLayer.Interfaces
{
	public interface IMaterialsRepository
	{
		IEnumerable<Material> GetAllMaterial(bool includeDirectory = false);
		Material GetMaterialById(int materialId, bool includeDirectory = false);
		void SaveDirectory(Material material);
		void DeleteMaterial(Material material);
	}
}
