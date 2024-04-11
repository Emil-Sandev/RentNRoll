using RentNRoll.Data.Models;

namespace RentNRoll.Data.Seeders
{
	public class BrandSeeder : ISeeder
	{
		public async Task SeedAsync(RentNRollDBContext context, IServiceProvider serviceProvider)
		{
			if (context.Brands.Any()) return;

			await context.Brands.AddRangeAsync(new Brand[]
			{
				new Brand { Name = "Volkswagen", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "BMW", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Audi", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Mercedes", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Mini Cooper", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Honda", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Mazda", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Fiat", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Alfa Romeo", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Subaru", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Lotus", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Porsche", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Toyota", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Tesla", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Nissan", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Suzuki", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Jeep", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Ford", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Peugot", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Jaguar", CreatedOn = DateTime.UtcNow },
				new Brand { Name = "Chevrolet", CreatedOn = DateTime.UtcNow },
			});

			await context.SaveChangesAsync();
		}
	}
}
