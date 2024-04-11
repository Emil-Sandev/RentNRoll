using Microsoft.AspNetCore.Mvc;
using RentNRoll.Services.Data.Categories;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

		[HttpGet("getCategories")]
		public async Task<ActionResult<IEnumerable<string>>> GetCategories()
		{
			var categories = await _categoryService.GetCategoriesAsync();
			return Ok(categories);
		}
	}
}
