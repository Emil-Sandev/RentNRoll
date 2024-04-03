using RentNRoll.Data.Common.Models;
using static RentNRoll.Common.GlobalConstants;
using System.ComponentModel.DataAnnotations;

namespace RentNRoll.Data.Models
{
	public class Category : BaseModel<int>
	{
		[Required]
		[MaxLength(CategoryNameMaxLength)]
		public string Name { get; set; } = null!;
	}
}
