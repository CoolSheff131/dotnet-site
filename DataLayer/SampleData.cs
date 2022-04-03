using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
	public static class SampleData
	{
		public static void InitData(EFDBContext context)
		{
			if (!context.Directory.Any())
			{
				context.Directory.Add(new Entities.Directory() { Title = "First Directory", Html = "<b>Content</b>" });
				context.Directory.Add(new Entities.Directory() { Title = "second Directory", Html = "<b>Content</b>" });
				context.SaveChanges();

				context.Material.Add(new Entities.Material() { Title = "First material", Html = "<b>Material content</b>", DirectoryId = context.Directory.First().Id });
				context.Material.Add(new Entities.Material() { Title = "Second material", Html = "<b>Material content</b>", DirectoryId = context.Directory.First().Id });
				context.Material.Add(new Entities.Material() { Title = "Third material", Html = "<b>Material content</b>", DirectoryId = context.Directory.Last().Id });
				context.SaveChanges();
			}
		}
	}
}
