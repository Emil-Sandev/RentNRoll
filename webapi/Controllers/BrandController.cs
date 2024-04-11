using Microsoft.AspNetCore.Mvc;
using RentNRoll.Services.Data.Brands;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class BrandController : ControllerBase
	{
		private readonly IBrandService _brandService;

		public BrandController(IBrandService brandService) => _brandService = brandService;

		[HttpGet("getBrands")]
		public async Task<ActionResult<IEnumerable<string>>> GetBrands()
		{
			var brands = await _brandService.GetBrandsAsync();
			return Ok(brands);
		}
	}
}
