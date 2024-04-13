namespace RentNRoll.Services.Data.Categories
{
	public interface ICategoryService
	{
		Task<IEnumerable<string>> GetCategoriesAsync();

		Task<int> GetCategoryIdByNameAsync(string name);
	}
}
