using static RentNRoll.Common.GlobalConstants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace RentNRoll.Data.Seeders
{
	public class RoleSeeder : ISeeder
	{
		public async Task SeedAsync(RentNRollDBContext context, IServiceProvider serviceProvider)
		{
			var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			if (await roleManager.FindByNameAsync(AdministratorRole) is null)
			{
				await roleManager.CreateAsync(new IdentityRole(AdministratorRole));
			}
		}
	}
}
