using Microsoft.EntityFrameworkCore;
using RentNRoll.Data.Common.Repositories;
using RentNRoll.Data.Models;

namespace RentNRoll.Services.Data.Categories
{
	public class CategoryService : ICategoryService
	{
		private readonly IRepository<Category> _categoryRepository;

		public CategoryService(IRepository<Category> categoryRepository) => _categoryRepository = categoryRepository;

		public async Task<IEnumerable<string>> GetCategoriesAsync() => await _categoryRepository.AllAsNoTracking().Select(c => c.Name).ToListAsync();
	}
}
