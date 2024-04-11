namespace RentNRoll.Web.DTOs.Car
{
	public class PagedAndFilteredCarDTO
	{
        public int TotalCount { get; set; }
        public IEnumerable<CarDTO> Cars { get; set; } = new HashSet<CarDTO>();
    }
}
