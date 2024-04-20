namespace RentNRoll.Web.DTOs.User
{
	public class UsersAdminDTO
	{
        public int TotalCount { get; set; }
        public IEnumerable<UserDTO> Users { get; set; } = new HashSet<UserDTO>();
    }
}
