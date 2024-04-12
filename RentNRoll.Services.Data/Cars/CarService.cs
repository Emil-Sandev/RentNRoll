using Microsoft.EntityFrameworkCore;
using RentNRoll.Data.Common.Repositories;
using RentNRoll.Data.Models;
using RentNRoll.Services.Mapping;
using RentNRoll.Web.DTOs.Car;

namespace RentNRoll.Services.Data.Cars
{
    public class CarService : ICarService
    {
        private readonly IDeletableEntityRepository<Car> _carRepository;

        public CarService(IDeletableEntityRepository<Car> carRepository) => _carRepository = carRepository;

        public async Task<CarDetailsDTO> GetCarDetailsAsync(int id)
        {
            var details = await _carRepository.AllAsNoTracking().Where(c => c.Id == id).To<CarDetailsDTO>().FirstAsync();
            return details;
        }

        public async Task<PagedAndFilteredCarDTO> GetCarsPageAsync(CarQueryModel queryModel)
        {
            IQueryable<Car> carQuery = _carRepository.AllAsNoTracking().Where(c => c.PricePerDay >= queryModel.MinPrice && c.PricePerDay <= queryModel.MaxPrice && c.IsAvailable);

            if (!string.IsNullOrEmpty(queryModel.Brand))
            {
                carQuery = carQuery.Where(c => c.Brand.Name == queryModel.Brand);
            }

            if (!string.IsNullOrEmpty(queryModel.Category))
            {
                carQuery = carQuery.Where(c => c.Category.Name == queryModel.Category);
            }

            IEnumerable<CarDTO> cars = await carQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.CarsPerPage)
                .Take(queryModel.CarsPerPage)
                .To<CarDTO>()
                .ToListAsync();

            int totalCount = carQuery.Count();

            return new PagedAndFilteredCarDTO
            {
                TotalCount = totalCount,
                Cars = cars
            };
        }
    }
}
