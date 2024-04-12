using RentNRoll.Data.Common.Repositories;
using RentNRoll.Data.Models;
using RentNRoll.Services.Data.Cars;
using RentNRoll.Services.Mapping;
using RentNRoll.Web.DTOs.Rental;

namespace RentNRoll.Services.Data.Rentals
{
	public class RentalService : IRentalService
	{
		private readonly IRepository<Rental> _rentalRepository;
		private readonly ICarService _carService;

		public RentalService(IRepository<Rental> rentalRepository, ICarService carService)
		{
			_rentalRepository = rentalRepository;
			_carService = carService;
		}

		public async Task CreateRentalAsync(CreateRentalDTO createRentalDTO)
		{
			await _carService.MakeCarUnavailableAsync(createRentalDTO.CarId);
			await _rentalRepository.AddAsync(AutoMapperConfig.MapperInstance.Map<Rental>(createRentalDTO));
			await _rentalRepository.SaveChangesAsync();
		}
	}
}
