using BusinessLayer.Interfaces;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
	internal class EFDirectoriesRepository : IDirectoriesRepository
	{
		private EFDBContext context;
		public EFDirectoriesRepository(EFDBContext context)
		{
			this.context = context;
		}

		public IEnumerable<DataLayer.Entities.Directory> GetAllDirectories(bool includeMaterials = false)
		{
			if (includeMaterials)
				return context.Set<DataLayer.Entities.Directory>().Include(x => x.Materials).AsNoTracking().ToList();
			else
				return context.Directory.ToList();
		}

		public DataLayer.Entities.Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
		{
			if (includeMaterials)
			{
				return context.Set<DataLayer.Entities.Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
			}
			else
			{
				return context.Directory.FirstOrDefault(x => x.Id == directoryId);
			}
		}

		public void SaveDirectory(DataLayer.Entities.Directory directory)
		{
			if(directory.Id == 0)
			{
				context.Directory.Add(directory);
			}
			else
			{
				context.Entry(directory).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public void DeleteDirectory(DataLayer.Entities.Directory directory)
		{
			context.Directory.Remove(directory);
			context.SaveChanges();
		}

	}
}
