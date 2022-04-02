using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
	public class EFDBContext : DbContext
	{
		public DbSet<Entities.Directory> Directory { get; set; }
		public DbSet<Material> Material { get; set; }

		public EFDBContext(DbContextOptions<EFDBContext> options): base(options) { }
	}

	public class EFDBContextFactory: IDesignTimeDbContextFactory<EFDBContext>
	{
		public EFDBContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
			optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB; Database=site; Persist Security Info=false; User ID='sa'; Password='sa'; MultipleActiveResultSets=True; Trusted_Connection=False;");
			return new EFDBContext(optionsBuilder.Options);
		}
	}

}
