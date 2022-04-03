using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
	internal class EFDirectoriesRepository : IDirectoriesRepository
	{
		public void DeleteDirectory(DataLayer.Entities.Directory achieve)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<DataLayer.Entities.Directory> GetAllDirectories(bool includeMaterials = false)
		{
			throw new NotImplementedException();
		}

		public DataLayer.Entities.Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
		{
			throw new NotImplementedException();
		}

		public void SaveDirectory(DataLayer.Entities.Directory achieve)
		{
			throw new NotImplementedException();
		}
	}
}
