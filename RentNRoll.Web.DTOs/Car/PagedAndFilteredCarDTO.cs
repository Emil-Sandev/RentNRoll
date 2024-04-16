namespace RentNRoll.Web.DTOs.Car
{
	public class PagedAndFilteredCarDTO<T>
	{
        public int TotalCount { get; set; }
        public IEnumerable<T> Cars { get; set; } = new HashSet<T>();
    }
}
