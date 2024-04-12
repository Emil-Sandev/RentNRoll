using RentNRoll.Data.Models;

namespace RentNRoll.Services.Data.Users
{
	public interface IUserService
	{
		Task<bool> ExistsByEgnAsync(string egn);

		string GetUserIdByEmail(string email);
	}
}
