
using Microsoft.EntityFrameworkCore;
using RentNRoll.Data.Common.Repositories;
using RentNRoll.Data.Models;

namespace RentNRoll.Services.Data.Brands
{
	public class BrandService : IBrandService
	{
		private readonly IRepository<Brand> _brandRepository;

		public BrandService(IRepository<Brand> brandRepository) => _brandRepository = brandRepository;

		public async Task<int> GetBrandIdByNameAsync(string name) 
		{
			var brand = await _brandRepository.AllAsNoTracking().FirstAsync(b=>b.Name == name);
			return brand.Id;
		}

		public async Task<IEnumerable<string>> GetBrandsAsync() => await _brandRepository.AllAsNoTracking().Select(b => b.Name).ToListAsync();
	}
}
