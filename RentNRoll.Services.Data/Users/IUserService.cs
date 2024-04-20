using RentNRoll.Data.Models;
using RentNRoll.Web.DTOs.User;

namespace RentNRoll.Services.Data.Users
{
	public interface IUserService
	{
		Task<bool> ExistsByEgnAsync(string egn);

		string GetUserIdByEmail(string email);

		Task<UsersAdminDTO> GetUsersInfoAsync(int page);

		Task DeleteUserByUsernameAsync(string username);
	}
}
