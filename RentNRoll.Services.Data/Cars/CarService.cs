using Microsoft.EntityFrameworkCore;
using RentNRoll.Data.Common.Repositories;
using RentNRoll.Data.Models;
using RentNRoll.Services.Data.Brands;
using RentNRoll.Services.Data.Categories;
using RentNRoll.Services.Images;
using RentNRoll.Services.Mapping;
using RentNRoll.Web.DTOs.Car;

namespace RentNRoll.Services.Data.Cars
{
    public class CarService : ICarService
    {
        private readonly IDeletableEntityRepository<Car> _carRepository;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        private readonly ICloudinaryService _cloudinaryService;

        public CarService(IDeletableEntityRepository<Car> carRepository, ICategoryService categoryService, IBrandService brandService, ICloudinaryService cloudinaryService)
        {
            _carRepository = carRepository;
            _categoryService = categoryService;
            _brandService = brandService;
            _cloudinaryService = cloudinaryService;
        }

        public int GetCarIdByModel(string model) => _carRepository.All().First(c => c.Model == model).Id;

        public async Task<CarDetailsDTO> GetCarDetailsAsync(int id)
        {
            var details = await _carRepository.AllAsNoTracking().Where(c => c.Id == id).To<CarDetailsDTO>().FirstAsync();
            return details;
        }

        public async Task<PagedAndFilteredCarDTO<T>> GetCarsPageAsync<T>(CarQueryModel queryModel)
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

            IEnumerable<T> cars = await carQuery
                .Skip((queryModel.CurrentPage - 1) * queryModel.CarsPerPage)
                .Take(queryModel.CarsPerPage)
                .To<T>()
                .ToListAsync();

            int totalCount = carQuery.Count();

            return new PagedAndFilteredCarDTO<T>
            {
                TotalCount = totalCount,
                Cars = cars
            };
        }

        public async Task MakeCarUnavailableAsync(int id)
        {
            var car = _carRepository.All().First(c => c.Id == id);
            car.IsAvailable = false;
            _carRepository.Update(car);
            await _carRepository.SaveChangesAsync();
        }

        public async Task CreateCarAsync(CreateCarDTO createCarDTO)
        {
            var car = new Car
            {
                BrandId = await _brandService.GetBrandIdByNameAsync(createCarDTO.Brand),
                CategoryId = await _categoryService.GetCategoryIdByNameAsync(createCarDTO.Category),
                Model = createCarDTO.Model,
                Year = createCarDTO.Year,
                Seats = createCarDTO.Seats,
                PricePerDay = createCarDTO.PricePerDay,
                Description = createCarDTO.Description,
                ImageUrl = _cloudinaryService.UploadImage(createCarDTO.Image),
                LicensePlate = createCarDTO.LicensePlate,
                IsAvailable = true,
                CreatedOn = DateTime.UtcNow,
            };

            await _carRepository.AddAsync(car);
            await _carRepository.SaveChangesAsync();
        }

        public async Task DeleteCarByIdAsync(int id)
        {
            var carToDelete = _carRepository.All().First(c => c.Id == id);
            _carRepository.HardDelete(carToDelete);
            await _carRepository.SaveChangesAsync();
        }
    }
}
