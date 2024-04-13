namespace RentNRoll.Data.Seeders
{
	public class RentNRollSeeder : ISeeder
	{
		public async Task SeedAsync(RentNRollDBContext context, IServiceProvider serviceProvider)
		{
			if (context is null) throw new ArgumentNullException(nameof(context));

			if (serviceProvider is null) throw new ArgumentNullException(nameof(serviceProvider));

			var seeders = new List<ISeeder>
			{
				new BrandSeeder(),
				new CategorySeeder(),
				new CarSeeder(),
				new RoleSeeder(),
				new AdminSeeder(),
			};

			foreach (var seeder in seeders)
			{
				await seeder.SeedAsync(context, serviceProvider);
			}
		}
	}
}
