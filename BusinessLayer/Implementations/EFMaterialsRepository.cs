using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Implementations
{
	public class EFMaterialsRepository : IMaterialsRepository
	{
		private EFDBContext context;

		public EFMaterialsRepository(EFDBContext context)
		{
			this.context = context;
		}
		public IEnumerable<Material> GetAllMaterial(bool includeDirectory = false)
		{
			if (includeDirectory)
			{
				return context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
			}
			else
			{
				return context.Material.ToList();
			}
		}

		public Material GetMaterialById(int materialId, bool includeDirectory = false)
		{
			if (includeDirectory)
			{
				return context.Set<Material>().Include(x=>x.Directory).AsNoTracking().FirstOrDefault(x=>x.Id == materialId);
			}
			else
			{
				return context.Material.FirstOrDefault(x=>x.Id == materialId);
			}
		}

		public void SaveMaterial(Material material)
		{
			if(material.Id == 0)
			{
				context.Material.Add(material);
			}
			else
			{
				context.Entry(material).State = EntityState.Modified;
			}
			context.SaveChanges();
		}

		public void DeleteMaterial(Material material)
		{
			context.Material.Remove(material);
			context.SaveChanges();
		}

	}
}
