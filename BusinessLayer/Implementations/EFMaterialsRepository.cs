using BusinessLayer.Interfaces;
using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
	internal class EFMaterialsRepository : IMaterialsRepository
	{
		public void DeleteMaterial(Material material)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Material> GetAllMaterial(bool includeDirectory = false)
		{
			throw new NotImplementedException();
		}

		public Material GetMaterialById(int materialId, bool includeDirectory = false)
		{
			throw new NotImplementedException();
		}

		public void SaveDirectory(Material material)
		{
			throw new NotImplementedException();
		}
	}
}
