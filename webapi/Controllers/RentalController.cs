using Microsoft.AspNetCore.Mvc;
using RentNRoll.Services.Data.Rentals;
using RentNRoll.Web.DTOs.Rental;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class RentalController : ControllerBase
	{
		private readonly IRentalService _rentalService;

		public RentalController(IRentalService rentalService) => _rentalService = rentalService;

		[HttpGet("getUserRentals")]
		public async Task<ActionResult<IEnumerable<RentalDetailsUserDTO>>> GetUserRentals(string username)
		{
			try
			{
				var rentalDetails = await _rentalService.GetRentalDetailsByUsernameAsync(username);
				return Ok(rentalDetails);
			}
			catch
			{
				return StatusCode(500);
			}
		}
	}
}
