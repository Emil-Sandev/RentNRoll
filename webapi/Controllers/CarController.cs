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
        public async Task<ActionResult<PagedAndFilteredCarDTO>> GetCars([FromQuery] CarQueryModel queryModel)
        {
            var pagedAndFilteredDto = await _carService.GetCarsPageAsync(queryModel);
            return Ok(pagedAndFilteredDto);
        }

        [HttpGet("getCarDetails/{id}")]
        public async Task<ActionResult<CarDetailsDTO>> GetCars(int id)
        {
            var carDetailsDTO = await _carService.GetCarDetailsAsync(id);
            return Ok(carDetailsDTO);
        }
    }
}
