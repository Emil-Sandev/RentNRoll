using Microsoft.EntityFrameworkCore;
using RentNRoll.Data.Common.Repositories;
using RentNRoll.Data.Models;

namespace RentNRoll.Services.Data.Users
{
	public class UserService : IUserService
	{
		private readonly IRepository<ApplicationUser> _userRepository;

		public UserService(IRepository<ApplicationUser> userRepository) => _userRepository = userRepository;

		public async Task<bool> ExistsByEgnAsync(string egn) => await _userRepository.AllAsNoTracking().AnyAsync(u => u.EGN == egn);

		public string GetUserIdByEmail(string email) => _userRepository.AllAsNoTracking().First(u => u.Email == email).Id;
	}
}
