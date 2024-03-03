using GrooveArcade.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrooveArcade.Data
{
	public class GrooveArcadeDbContext : IdentityDbContext<ApplicationUser>
	{
		public GrooveArcadeDbContext(DbContextOptions<GrooveArcadeDbContext> options) : base(options) { }
	}
}
