using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using RentNRoll.Data.Models;
using static RentNRoll.Common.GlobalConstants;

namespace RentNRoll.Data.Seeders
{
	public class AdminSeeder : ISeeder
	{
		public async Task SeedAsync(RentNRollDBContext context, IServiceProvider serviceProvider)
		{
			var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

			var admin = new ApplicationUser
			{
				UserName = "Admin",
				Email = "rentnroll@abv.bg",
				FirstName = "Admin",
				LastName = "Adminov",
				EGN = "0000000000",
				PhoneNumber = "0000000000",
				EmailConfirmed = true,
			};

			var result = await userManager.CreateAsync(admin, "Parola!123");

			if (result.Succeeded)
			{
				await userManager.AddToRoleAsync(admin, AdministratorRole);
			}
		}
	}
}
