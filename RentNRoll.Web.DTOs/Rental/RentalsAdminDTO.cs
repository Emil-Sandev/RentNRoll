namespace RentNRoll.Web.DTOs.Rental
{
	public class RentalsAdminDTO
	{
		public int TotalCount { get; set; }
		public IEnumerable<RentalAdminDTO> Rentals { get; set; } = new HashSet<RentalAdminDTO>();
	}
}
