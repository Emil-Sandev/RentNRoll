using RentNRoll.Web.DTOs.Rental;

namespace RentNRoll.Services.Data.Rentals
{
	public interface IRentalService
	{
		Task CreateRentalAsync(CreateRentalDTO createRentalDTO);

		Task<IEnumerable<RentalDetailsUserDTO>> GetRentalDetailsByUsernameAsync(string username);

		Task<RentalsAdminDTO> GetRentals(int page);

		Task DeleteRentalByCarModelAsync(string model);
	}
}
