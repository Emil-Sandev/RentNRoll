using RentNRoll.Data.Models;

namespace RentNRoll.Data.Seeders
{
	public class CategorySeeder : ISeeder
	{
		public async Task SeedAsync(RentNRollDBContext context, IServiceProvider serviceProvider)
		{
			if (context.Categories.Any()) return;

			await context.Categories.AddRangeAsync(new Category[]
			{
				new Category { Name = "Sedan", CreatedOn = DateTime.UtcNow },
				new Category { Name = "SUV", CreatedOn = DateTime.UtcNow },
				new Category { Name = "MPV", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Coupe", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Hatchback", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Convertible", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Electric", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Hybrid", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Van", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Minivan", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Pickup", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Roadster", CreatedOn = DateTime.UtcNow },
				new Category { Name = "Sports car", CreatedOn = DateTime.UtcNow },
			});
		}
	}
}
