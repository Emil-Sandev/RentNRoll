using RentNRoll.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentNRoll.Data
{
	public class RentNRollDBContext : IdentityDbContext<ApplicationUser>
	{
		public RentNRollDBContext(DbContextOptions<RentNRollDBContext> options) : base(options) { }

		public DbSet<Brand> Brands { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Car> Cars { get; set; }
		public DbSet<Rental> Rentals { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			// decimal precisions
			builder.Entity<Car>().Property(c => c.PricePerDay).HasPrecision(18, 2);
			builder.Entity<Rental>().Property(r => r.TotalPrice).HasPrecision(18, 2);

			var entityTypes = builder.Model.GetEntityTypes();

			// disable cascade delete
			var cascadeKeys = entityTypes.SelectMany(et => et.GetForeignKeys().Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade)).ToList();
			cascadeKeys.ForEach(ck => ck.DeleteBehavior = DeleteBehavior.Restrict);
		}
	}
}
