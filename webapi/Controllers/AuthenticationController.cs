using RentNRoll.Data.Models;
using RentNRoll.Web.DTOs.Login;
using RentNRoll.Web.DTOs.Refresh;
using RentNRoll.Web.DTOs.Register;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using RentNRoll.Services.Token;
using RentNRoll.Services.Mapping;
using RentNRoll.Services.Data.Users;

namespace webapi.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly ITokenService _tokenService;
		private readonly IUserService _userService;
		private readonly ILogger<AuthenticationController> _logger;

		public AuthenticationController(UserManager<ApplicationUser> userManager, ITokenService tokenService, IUserService userService, ILogger<AuthenticationController> logger)
		{
			_userManager = userManager;
			_tokenService = tokenService;
			_userService = userService;
			_logger = logger;
		}

		[HttpPost("register")]
		[ProducesResponseType(StatusCodes.Status409Conflict)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Register([FromBody] RegisterDTO model)
		{
			_logger.LogInformation("Register called");

			if (await _userManager.FindByNameAsync(model.Username) is not null)
				return Conflict("Another user is using this username.");

			if (await _userManager.FindByEmailAsync(model.Email) is not null)
				return Conflict("Another user is using this email.");

			if (await _userService.ExistsByEgnAsync(model.EGN))
				return Conflict("Another user is using this EGN.");

			var user = AutoMapperConfig.MapperInstance.Map<ApplicationUser>(model);

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				_logger.LogInformation("Register succeeded");
				return Ok("User successfully created");
			}

			return StatusCode(StatusCodes.Status500InternalServerError,
				   $"Failed to create user: {string.Join(" ", result.Errors.Select(e => e.Description))}");
		}

		[HttpPost("login")]
		[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResponse))]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Login([FromBody] LoginDTO model)
		{
			_logger.LogInformation("Login called");

			var user = await _userManager.FindByNameAsync(model.Username);

			if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
				return Unauthorized();

			JwtSecurityToken token = _tokenService.GenerateJwt(model.Username);

			var refreshToken = _tokenService.GenerateRefreshToken();

			user.RefreshToken = refreshToken;
			user.RefreshTokenExpiry = DateTime.UtcNow.AddHours(6);

			await _userManager.UpdateAsync(user);

			_logger.LogInformation("Login succeeded");

			return Ok(new LoginResponse
			{
				JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = token.ValidTo,
				RefreshToken = refreshToken
			});
		}

		[HttpPost("refresh")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Refresh([FromBody] RefreshModel model)
		{
			_logger.LogInformation("Refresh called");

			var principal = _tokenService.GetPrincipalFromExpiredToken(model.AccessToken);

			if (principal?.Identity?.Name is null)
				return Unauthorized();

			var user = await _userManager.FindByNameAsync(principal.Identity.Name);

			if (user is null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
				return Unauthorized();

			var token = _tokenService.GenerateJwt(principal.Identity.Name);

			_logger.LogInformation("Refresh succeeded");

			return Ok(new LoginResponse
			{
				JwtToken = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = token.ValidTo,
				RefreshToken = model.RefreshToken
			});
		}

		[Authorize]
		[HttpDelete("revoke")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public async Task<IActionResult> Revoke()
		{
			_logger.LogInformation("Revoke called");

			var username = HttpContext.User.Identity?.Name;

			if (username is null)
				return Unauthorized();

			var user = await _userManager.FindByNameAsync(username);

			if (user is null)
				return Unauthorized();

			user.RefreshToken = null;

			await _userManager.UpdateAsync(user);

			_logger.LogInformation("Revoke succeeded");

			return Ok();
		}
	}
}
