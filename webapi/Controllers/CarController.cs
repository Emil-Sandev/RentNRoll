using Microsoft.AspNetCore.Mvc;
using RentNRoll.Services.Data.Cars;
using RentNRoll.Web.DTOs.Car;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class CarController : ControllerBase
	{
		private readonly ICarService _carService;

		public CarController(ICarService carService) => _carService = carService;

		[HttpGet("getCars")]
		public async Task<ActionResult<PagedAndFilteredCarDTO<CarDTO>>> GetCars([FromQuery] CarQueryModel queryModel)
		{
			var pagedAndFilteredDto = await _carService.GetCarsPageAsync<CarDTO>(queryModel);
			return Ok(pagedAndFilteredDto);
		}

		[HttpGet("getAdminCars")]
        public async Task<ActionResult<PagedAndFilteredCarDTO<CarDetailsDTO>>> GetAdminCars([FromQuery] CarQueryModel queryModel)
        {
            var pagedAndFilteredDto = await _carService.GetCarsPageAsync<CarDetailsDTO>(queryModel);
            return Ok(pagedAndFilteredDto);
        }

        [HttpGet("getCarDetails/{id}")]
		public async Task<ActionResult<CarDetailsDTO>> GetCars(int id)
		{
			var carDetailsDTO = await _carService.GetCarDetailsAsync(id);
			return Ok(carDetailsDTO);
		}

		[HttpPost("createCar")]
		public async Task<IActionResult> CreateCar([FromForm] CreateCarDTO createCarDTO)
		{
			try
			{
				await _carService.CreateCarAsync(createCarDTO);
				return Ok("Successfully created car.");
			}
			catch (Exception ex) 
			{
				Console.WriteLine(ex.Message);
				return BadRequest(ex.Message);
			}
		}
	}
}
