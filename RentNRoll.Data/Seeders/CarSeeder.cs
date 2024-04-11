using RentNRoll.Data.Models;

namespace RentNRoll.Data.Seeders
{
	public class CarSeeder : ISeeder
	{
		public async Task SeedAsync(RentNRollDBContext context, IServiceProvider serviceProvider)
		{
			if (context.Cars.Any()) return;

			await context.Cars.AddRangeAsync(new Car[]
			{
				// Volkswagen cars
                new Car { Model = "Volkswagen Golf", BrandId = 1, CategoryId = 5, Year = 2022, LicensePlate = "ABC123", PricePerDay = 50, IsAvailable = true, Description = "Compact hatchback with great fuel efficiency.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Volkswagen Passat", BrandId = 1, CategoryId = 1, Year = 2021, LicensePlate = "DEF456", PricePerDay = 70, IsAvailable = true, Description = "Mid-size sedan offering comfort and performance.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // BMW cars
				new Car { Model = "BMW 5 Series", BrandId = 2, CategoryId = 1, Year = 2022, LicensePlate = "JKL012", PricePerDay = 90, IsAvailable = true, Description = "Executive sedan known for its elegance and performance.", Seats = 5, CreatedOn = DateTime.UtcNow },
                new Car { Model = "BMW X5", BrandId = 2, CategoryId = 2, Year = 2020, LicensePlate = "GHI789", PricePerDay = 100, IsAvailable = true, Description = "Luxury SUV with spacious interior and powerful engine.", Seats = 7, CreatedOn = DateTime.UtcNow },
                
                // Audi cars
				new Car { Model = "Audi A4", BrandId = 3, CategoryId = 1, Year = 2023, LicensePlate = "PQR678", PricePerDay = 80, IsAvailable = true, Description = "Premium sedan offering comfort and refinement.", Seats = 5, CreatedOn = DateTime.UtcNow },
                new Car { Model = "Audi Q5", BrandId = 3, CategoryId = 2, Year = 2021, LicensePlate = "MNO345", PricePerDay = 95, IsAvailable = true, Description = "Compact luxury SUV with advanced technology features.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Mercedes cars
                new Car { Model = "Mercedes-Benz E-Class", BrandId = 4, CategoryId = 1, Year = 2022, LicensePlate = "STU901", PricePerDay = 110, IsAvailable = true, Description = "Luxurious sedan with cutting-edge technology and comfort features.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Mercedes-Benz GLC", BrandId = 4, CategoryId = 2, Year = 2021, LicensePlate = "VWX234", PricePerDay = 120, IsAvailable = true, Description = "Compact luxury SUV with a smooth ride and upscale interior.", Seats = 5, CreatedOn = DateTime.UtcNow },

                // Mini Cooper cars
				new Car { Model = "Mini Cooper Countryman", BrandId = 5, CategoryId = 2, Year = 2022, LicensePlate = "BCD890", PricePerDay = 90, IsAvailable = true, Description = "Compact crossover with a spacious interior and lively performance.", Seats = 5, CreatedOn = DateTime.UtcNow },
                new Car { Model = "Mini Cooper Convertible", BrandId = 5, CategoryId = 6, Year = 2020, LicensePlate = "YZA567", PricePerDay = 80, IsAvailable = true, Description = "Fun and stylish convertible with agile handling and a retro design.", Seats = 4, CreatedOn = DateTime.UtcNow },

                // Honda cars
                new Car { Model = "Honda Civic", BrandId = 6, CategoryId = 1, Year = 2023, LicensePlate = "EFG123", PricePerDay = 60, IsAvailable = true, Description = "Reliable and fuel-efficient sedan with a comfortable ride and modern features.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Honda CR-V", BrandId = 6, CategoryId = 2, Year = 2021, LicensePlate = "HIJ456", PricePerDay = 75, IsAvailable = true, Description = "Popular compact SUV known for its practicality, spacious cabin, and strong resale value.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Mazda cars
                new Car { Model = "Mazda CX-5", BrandId = 7, CategoryId = 2, Year = 2022, LicensePlate = "KLM789", PricePerDay = 85, IsAvailable = true, Description = "Stylish and sporty SUV with responsive handling and a premium interior.", Seats = 5, CreatedOn = DateTime.UtcNow},
				new Car { Model = "Mazda3", BrandId = 7, CategoryId = 5, Year = 2023, LicensePlate = "NOP012", PricePerDay = 65, IsAvailable = true, Description = "Dynamic and fuel-efficient hatchback with advanced safety features.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Fiat cars
                new Car { Model = "Fiat 500", BrandId = 8, CategoryId = 5, Year = 2020, LicensePlate = "QRS345", PricePerDay = 55, IsAvailable = true, Description = "Chic and compact city car with retro styling and nimble handling.", Seats = 4, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Fiat Panda", BrandId = 8, CategoryId = 5, Year = 2021, LicensePlate = "TUV678", PricePerDay = 50, IsAvailable = true, Description = "Affordable and practical city car with a spacious interior and low running costs.", Seats = 4, CreatedOn = DateTime.UtcNow },
                
                // Alfa Romeo cars
                new Car { Model = "Alfa Romeo Giulia", BrandId = 9, CategoryId = 1, Year = 2022, LicensePlate = "WXY901", PricePerDay = 95, IsAvailable = true, Description = "Italian luxury sedan with striking design and thrilling performance.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Alfa Romeo Stelvio", BrandId = 9, CategoryId = 2, Year = 2020, LicensePlate = "ZAB234", PricePerDay = 105, IsAvailable = true, Description = "Sporty and stylish SUV with agile handling and a potent engine.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Subaru cars
				new Car { Model = "Subaru WRX", BrandId = 10, CategoryId = 1, Year = 2023, LicensePlate = "EFG890", PricePerDay = 90, IsAvailable = true, Description = "High-performance sedan with sharp handling and turbocharged power.", Seats = 5, CreatedOn = DateTime.UtcNow },
                new Car { Model = "Subaru Outback", BrandId = 10, CategoryId = 2, Year = 2021, LicensePlate = "BCD567", PricePerDay = 80, IsAvailable = true, Description = "Rugged and versatile wagon with standard all-wheel drive and a spacious interior.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Lotus cars
				new Car { Model = "Lotus Evora", BrandId = 11, CategoryId = 4, Year = 2021, LicensePlate = "KLM345", PricePerDay = 180, IsAvailable = true, Description = "Mid-engine sports car with exotic looks and exhilarating performance.", Seats = 2, CreatedOn = DateTime.UtcNow },
                new Car { Model = "Lotus Elise", BrandId = 11, CategoryId = 12, Year = 2020, LicensePlate = "HIJ012", PricePerDay = 150, IsAvailable = true, Description = "Lightweight and agile roadster with superb handling and a thrilling driving experience.", Seats = 2, CreatedOn = DateTime.UtcNow },
                
                // Porsche cars
                new Car { Model = "Porsche Cayenne", BrandId = 12, CategoryId = 2, Year = 2022, LicensePlate = "NOP678", PricePerDay = 200, IsAvailable = true, Description = "Luxurious and sporty SUV with exceptional performance and handling.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Porsche 911", BrandId = 12, CategoryId = 13, Year = 2023, LicensePlate = "QRS901", PricePerDay = 250, IsAvailable = true, Description = "Iconic sports car with timeless design and breathtaking performance.", Seats = 2, CreatedOn = DateTime.UtcNow },
                
                // Toyota cars
                new Car { Model = "Toyota Corolla", BrandId = 13, CategoryId = 1, Year = 2021, LicensePlate = "TUV234", PricePerDay = 65, IsAvailable = true, Description = "Reliable and fuel-efficient sedan known for its practicality and low maintenance costs.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Toyota RAV4", BrandId = 13, CategoryId = 2, Year = 2022, LicensePlate = "WXY567", PricePerDay = 85, IsAvailable = true, Description = "Popular compact SUV offering versatility, comfort, and strong resale value.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Tesla cars
                new Car { Model = "Tesla Model 3", BrandId = 14, CategoryId = 7, Year = 2023, LicensePlate = "ZAB890", PricePerDay = 150, IsAvailable = true, Description = "All-electric sedan with long range, rapid acceleration, and advanced technology features.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Tesla Model X", BrandId = 14, CategoryId = 7, Year = 2021, LicensePlate = "CDE012", PricePerDay = 200, IsAvailable = true, Description = "Electric SUV with futuristic design, ample cargo space, and impressive performance.", Seats = 7, CreatedOn = DateTime.UtcNow },
                
                // Nissan cars
                new Car { Model = "Nissan Altima", BrandId = 15, CategoryId = 1, Year = 2020, LicensePlate = "EFG345", PricePerDay = 60, IsAvailable = true, Description = "Comfortable and fuel-efficient sedan with a spacious cabin and smooth ride.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Nissan Rogue", BrandId = 15, CategoryId = 2, Year = 2022, LicensePlate = "HIJ678", PricePerDay = 80, IsAvailable = true, Description = "Compact SUV offering a comfortable ride, ample cargo space, and user-friendly technology.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Suzuki cars
				new Car { Model = "Suzuki Vitara", BrandId = 16, CategoryId = 2, Year = 2023, LicensePlate = "NOP234", PricePerDay = 70, IsAvailable = true, Description = "Compact SUV with rugged styling, comfortable ride, and practical features.", Seats = 5, CreatedOn = DateTime.UtcNow },
                new Car { Model = "Suzuki Swift", BrandId = 16, CategoryId = 5, Year = 2021, LicensePlate = "KLM901", PricePerDay = 45, IsAvailable = true, Description = "Compact hatchback with agile handling, fuel efficiency, and modern features.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Jeep cars
                new Car { Model = "Jeep Wrangler", BrandId = 17, CategoryId = 2, Year = 2020, LicensePlate = "QRS567", PricePerDay = 90, IsAvailable = true, Description = "Iconic off-road SUV with rugged styling and impressive capability on and off the road.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Jeep Grand Cherokee", BrandId = 17, CategoryId = 2, Year = 2021, LicensePlate = "TUV890", PricePerDay = 100, IsAvailable = true, Description = "Full-size SUV offering a comfortable ride, upscale interior, and strong towing capacity.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Ford cars
				new Car { Model = "Ford Explorer", BrandId = 18, CategoryId = 2, Year = 2023, LicensePlate = "ZAB345", PricePerDay = 90, IsAvailable = true, Description = "Popular SUV known for its versatility, comfort, and advanced safety features.", Seats = 7, CreatedOn = DateTime.UtcNow },
                new Car { Model = "Ford Focus", BrandId = 18, CategoryId = 5, Year = 2022, LicensePlate = "WXY012", PricePerDay = 55, IsAvailable = true, Description = "Compact hatchback with nimble handling and a spacious interior.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Peugot cars
				new Car { Model = "Peugeot 3008", BrandId = 19, CategoryId = 2, Year = 2020, LicensePlate = "FGH901", PricePerDay = 75, IsAvailable = true, Description = "Award-winning SUV offering comfort, refinement, and practicality.", Seats = 5, CreatedOn = DateTime.UtcNow },
                new Car { Model = "Peugeot 206", BrandId = 19, CategoryId = 5, Year = 2021, LicensePlate = "CDE678", PricePerDay = 50, IsAvailable = true, Description = "Stylish and efficient hatchback with a modern interior and enjoyable driving dynamics.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Jaguar cars
                new Car { Model = "Jaguar XE", BrandId = 20, CategoryId = 1, Year = 2022, LicensePlate = "IJK234", PricePerDay = 120, IsAvailable = true, Description = "Luxury sedan with dynamic handling, refined interior, and advanced technology.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Jaguar F-PACE", BrandId = 20, CategoryId = 2, Year = 2021, LicensePlate = "LMN567", PricePerDay = 140, IsAvailable = true, Description = "Luxurious SUV combining sporty performance with elegance and practicality.", Seats = 5, CreatedOn = DateTime.UtcNow },
                
                // Chevrolet cars
                new Car { Model = "Chevrolet Cruze", BrandId = 21, CategoryId = 1, Year = 2020, LicensePlate = "OPQ890", PricePerDay = 60, IsAvailable = true, Description = "Compact sedan with comfortable ride quality, spacious interior, and good fuel economy.", Seats = 5, CreatedOn = DateTime.UtcNow },
				new Car { Model = "Chevrolet Equinox", BrandId = 21, CategoryId = 2, Year = 2023, LicensePlate = "RST123", PricePerDay = 85, IsAvailable = true, Description = "Compact SUV offering a smooth ride, spacious cabin, and user-friendly features.", Seats = 5, CreatedOn = DateTime.UtcNow },
			});
		}
	}
}
