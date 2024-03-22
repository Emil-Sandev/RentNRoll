using RentNRoll.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RentNRoll.Data
{
	public class RentNRollDBContext : IdentityDbContext<ApplicationUser>
	{
		public RentNRollDBContext(DbContextOptions<RentNRollDBContext> options) : base(options) { }
	}
}
