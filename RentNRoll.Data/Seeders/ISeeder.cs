namespace RentNRoll.Data.Seeders
{
	public interface ISeeder
	{
		Task SeedAsync(RentNRollDBContext context, IServiceProvider serviceProvider);
	}
}
