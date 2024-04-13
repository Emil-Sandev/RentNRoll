using Microsoft.AspNetCore.Http;

namespace RentNRoll.Services.Images
{
	public interface ICloudinaryService
	{
		string? UploadImage(IFormFile? file);
	}
}
