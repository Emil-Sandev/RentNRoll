using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RentNRoll.Services.Token
{
	public interface ITokenService
	{
		ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
		JwtSecurityToken GenerateJwt(string username);
		string GenerateRefreshToken();
	}
}
