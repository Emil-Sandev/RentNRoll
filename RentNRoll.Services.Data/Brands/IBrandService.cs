namespace RentNRoll.Services.Data.Brands
{
	public interface IBrandService
	{
		Task<IEnumerable<string>> GetBrandsAsync();
	}
}
