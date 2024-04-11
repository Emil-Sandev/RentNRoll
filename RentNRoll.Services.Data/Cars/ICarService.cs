using RentNRoll.Web.DTOs.Car;

namespace RentNRoll.Services.Data.Cars
{
	public interface ICarService
	{
		Task<PagedAndFilteredCarDTO> GetCarsPageAsync(CarQueryModel queryModel);
	}
}
