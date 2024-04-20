using Microsoft.AspNetCore.Mvc;
using RentNRoll.Services.Data.Users;
using RentNRoll.Web.DTOs.User;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService) => _userService = userService;

		[HttpGet("getUsers/{page}")]
		public async Task<ActionResult<UsersAdminDTO>> GetUsers(int page)
		{
			var users = await _userService.GetUsersInfoAsync(page);
			return Ok(users);
		}

		[HttpDelete("deleteUser/{username}")]
		public async Task<IActionResult> GetUsers(string username)
		{
			await _userService.DeleteUserByUsernameAsync(username);
			return Ok("Successfully deleted user.");
		}
	}
}
