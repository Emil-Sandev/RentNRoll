using Microsoft.EntityFrameworkCore;
using RentNRoll.Data.Common.Repositories;
using RentNRoll.Data.Models;
using RentNRoll.Services.Mapping;
using RentNRoll.Web.DTOs.User;

namespace RentNRoll.Services.Data.Users
{
	public class UserService : IUserService
	{
		private readonly IRepository<ApplicationUser> _userRepository;

		public UserService(IRepository<ApplicationUser> userRepository) => _userRepository = userRepository;

		public async Task DeleteUserByUsernameAsync(string username)
		{
			var userToDelete = await _userRepository.AllAsNoTracking().FirstAsync(u => u.UserName == username);
			_userRepository.Delete(userToDelete);
			await _userRepository.SaveChangesAsync();
		}

		public async Task<bool> ExistsByEgnAsync(string egn) => await _userRepository.AllAsNoTracking().AnyAsync(u => u.EGN == egn);

		public string GetUserIdByEmail(string email) => _userRepository.AllAsNoTracking().First(u => u.Email == email).Id;

		public async Task<UsersAdminDTO> GetUsersInfoAsync(int page = 1)
		{
			int totalCount = await _userRepository.AllAsNoTracking().CountAsync();

			// 5 users per page
			var users = await _userRepository.AllAsNoTracking()
				.Skip((page - 1) * 5)
				.Take(5)
				.To<UserDTO>()
				.ToListAsync();

			return new UsersAdminDTO
			{
				TotalCount = totalCount,
				Users = users
			};
		}
	}
}
