using RentNRoll.Data.Models;
using RentNRoll.Web.DTOs.Car;

namespace RentNRoll.Services.Data.Cars
{
	public interface ICarService
	{
		Task<PagedAndFilteredCarDTO> GetCarsPageAsync(CarQueryModel queryModel);

		Task<CarDetailsDTO> GetCarDetailsAsync(int id);

		int GetCarIdByModel(string model);

		Task MakeCarUnavailableAsync(int id);

		Task CreateCarAsync(CreateCarDTO createCarDTO);
	}
}
