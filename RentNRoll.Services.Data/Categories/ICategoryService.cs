namespace RentNRoll.Services.Data.Categories
{
	public interface ICategoryService
	{
		public Task<IEnumerable<string>> GetCategoriesAsync();
	}
}
