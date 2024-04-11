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
                new Car { Model = "Volkswagen Golf", BrandId = 1, CategoryId = 5, Year = 2022, LicensePlate = "ABC123", PricePerDay = 50, IsAvailable = true, Description = "Compact hatchback with great fuel efficiency.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.cnet.com/a/img/resize/d4f81c0c40a17c6283f36c072ab73233ec88f13b/hub/2021/06/01/fb647f04-bc0d-474e-822a-ff0eef54dced/2022-vw-golf-r-012.jpg?auto=webp&width=1200" },
                new Car { Model = "Volkswagen Passat", BrandId = 1, CategoryId = 1, Year = 2021, LicensePlate = "DEF456", PricePerDay = 70, IsAvailable = true, Description = "Mid-size sedan offering comfort and performance.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://media.ed.edmunds-media.com/volkswagen/passat/2021/oem/2021_volkswagen_passat_sedan_r-line_fq_oem_1_1600.jpg"},
                
                // BMW cars
				new Car { Model = "BMW 5 Series", BrandId = 2, CategoryId = 1, Year = 2022, LicensePlate = "JKL012", PricePerDay = 90, IsAvailable = true, Description = "Executive sedan known for its elegance and performance.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.ytimg.com/vi/DjRdnEIhjfk/maxresdefault.jpg" },
                new Car { Model = "BMW X5", BrandId = 2, CategoryId = 2, Year = 2020, LicensePlate = "GHI789", PricePerDay = 100, IsAvailable = true, Description = "Luxury SUV with spacious interior and powerful engine.", Seats = 7, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.gaw.to/vehicles/photos/40/19/401956-2020-bmw-x5.jpg" },
                
                // Audi cars
				new Car { Model = "Audi A4", BrandId = 3, CategoryId = 1, Year = 2023, LicensePlate = "PQR678", PricePerDay = 80, IsAvailable = true, Description = "Premium sedan offering comfort and refinement.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.ytimg.com/vi/vBCsPli3HJI/maxresdefault.jpg" },
                new Car { Model = "Audi Q5", BrandId = 3, CategoryId = 2, Year = 2021, LicensePlate = "MNO345", PricePerDay = 95, IsAvailable = true, Description = "Compact luxury SUV with advanced technology features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://cdn.motor1.com/images/mgl/pEbEo/s3/2020-audi-q5.jpg" },
                
                // Mercedes cars
                new Car { Model = "Mercedes-Benz E-Class", BrandId = 4, CategoryId = 1, Year = 2022, LicensePlate = "STU901", PricePerDay = 110, IsAvailable = true, Description = "Luxurious sedan with cutting-edge technology and comfort features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.theoaklandpress.com/wp-content/uploads/2022/10/2022-Benz-E450-1.jpg?w=1024" },
                new Car { Model = "Mercedes-Benz GLC", BrandId = 4, CategoryId = 2, Year = 2021, LicensePlate = "VWX234", PricePerDay = 120, IsAvailable = true, Description = "Compact luxury SUV with a smooth ride and upscale interior.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.gaw.to/vehicles/photos/40/23/402336-2021-mercedes-benz-glc.jpg?640x400" },

                // Mini Cooper cars
				new Car { Model = "Mini Cooper Countryman", BrandId = 5, CategoryId = 2, Year = 2022, LicensePlate = "BCD890", PricePerDay = 90, IsAvailable = true, Description = "Compact crossover with a spacious interior and lively performance.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://hips.hearstapps.com/hmg-prod/images/2022-mini-cooper-countryman-mmp-1-1624641917.jpg" },
                new Car { Model = "Mini Cooper Convertible", BrandId = 5, CategoryId = 6, Year = 2020, LicensePlate = "YZA567", PricePerDay = 80, IsAvailable = true, Description = "Fun and stylish convertible with agile handling and a retro design.", Seats = 4, CreatedOn = DateTime.UtcNow, ImageUrl = "https://mediapool.bmwgroup.com/cache/P9/201912/P90378397/P90378397-mini-cooper-s-sidewalk-convertible-01-2020-600px.jpg" },

                // Honda cars
                new Car { Model = "Honda Civic", BrandId = 6, CategoryId = 1, Year = 2023, LicensePlate = "EFG123", PricePerDay = 60, IsAvailable = true, Description = "Reliable and fuel-efficient sedan with a comfortable ride and modern features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.cnet.com/a/img/resize/147b3a27f647c1386a8f9f1c4a1edef7bedf2ccf/hub/2022/08/31/8369f5c3-df36-4a1b-b4d2-d93badf1b755/ogi1-2023-honda-civic-type-r-001.jpg?auto=webp&fit=crop&height=900&width=1200" },
                new Car { Model = "Honda CR-V", BrandId = 6, CategoryId = 2, Year = 2021, LicensePlate = "HIJ456", PricePerDay = 75, IsAvailable = true, Description = "Popular compact SUV known for its practicality, spacious cabin, and strong resale value.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://media.ed.edmunds-media.com/honda/cr-v/2020/oem/2020_honda_cr-v_4dr-suv_touring_fq_oem_1_1600.jpg" },
                
                // Mazda cars
                new Car { Model = "Mazda CX-5", BrandId = 7, CategoryId = 2, Year = 2022, LicensePlate = "KLM789", PricePerDay = 85, IsAvailable = true, Description = "Stylish and sporty SUV with responsive handling and a premium interior.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://cdn.motor1.com/images/mgl/7qjE6/s3/2022-mazda-cx-5-rendering-front.jpg"},
                new Car { Model = "Mazda3", BrandId = 7, CategoryId = 5, Year = 2023, LicensePlate = "NOP012", PricePerDay = 65, IsAvailable = true, Description = "Dynamic and fuel-efficient hatchback with advanced safety features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://media.ed.edmunds-media.com/mazda/3/2024/oem/2024_mazda_3_4dr-hatchback_25-s-carbon-edition_fq_oem_1_1600.jpg" },
                
                // Fiat cars
                new Car { Model = "Fiat 500", BrandId = 8, CategoryId = 5, Year = 2020, LicensePlate = "QRS345", PricePerDay = 55, IsAvailable = true, Description = "Chic and compact city car with retro styling and nimble handling.", Seats = 4, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.carpixel.net/w/61f361d4153f637ff8587a417b6109d0/fiat-500-la-prima-wallpaper-hd-99501.jpg" },
                new Car { Model = "Fiat Panda", BrandId = 8, CategoryId = 5, Year = 2021, LicensePlate = "TUV678", PricePerDay = 50, IsAvailable = true, Description = "Affordable and practical city car with a spacious interior and low running costs.", Seats = 4, CreatedOn = DateTime.UtcNow, ImageUrl = "https://static.dir.bg/uploads/images/2020/05/22/2514713/768x576.jpg?_=1681247109" },
                
                // Alfa Romeo cars
                new Car { Model = "Alfa Romeo Giulia", BrandId = 9, CategoryId = 1, Year = 2022, LicensePlate = "WXY901", PricePerDay = 95, IsAvailable = true, Description = "Italian luxury sedan with striking design and thrilling performance.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.media.stellantis.com/cache/6/a/c/8/c/6ac8cf8318c9bc16eb5c14050f9b95a7ce184726.jpeg" },
                new Car { Model = "Alfa Romeo Stelvio", BrandId = 9, CategoryId = 2, Year = 2020, LicensePlate = "ZAB234", PricePerDay = 105, IsAvailable = true, Description = "Sporty and stylish SUV with agile handling and a potent engine.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.gaw.to/vehicles/photos/40/19/401924-2020-alfa-romeo-stelvio.jpg" },
                
                // Subaru cars
				new Car { Model = "Subaru WRX", BrandId = 10, CategoryId = 1, Year = 2023, LicensePlate = "EFG890", PricePerDay = 90, IsAvailable = true, Description = "High-performance sedan with sharp handling and turbocharged power.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://vehicle-photos-published.vauto.com/54/fc/e6/d0-155a-47cc-8fc5-4fa7a3c5da22/image-3.jpg" },
                new Car { Model = "Subaru Outback", BrandId = 10, CategoryId = 2, Year = 2021, LicensePlate = "BCD567", PricePerDay = 80, IsAvailable = true, Description = "Rugged and versatile wagon with standard all-wheel drive and a spacious interior.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://images.ams.bg/images/galleries/207632/subaru-outback-2021-4x4-kombi-na-pazara-v-evropa-1617010784_big.jpg" },
                
                // Lotus cars
				new Car { Model = "Lotus Evora", BrandId = 11, CategoryId = 4, Year = 2021, LicensePlate = "KLM345", PricePerDay = 180, IsAvailable = true, Description = "Mid-engine sports car with exotic looks and exhilarating performance.", Seats = 2, CreatedOn = DateTime.UtcNow, ImageUrl = "https://s3.amazonaws.com/images.gearjunkie.com/uploads/2022/08/LotusEvoraGT-2-2048x1366-1.jpg" },
                new Car { Model = "Lotus Elise", BrandId = 11, CategoryId = 12, Year = 2020, LicensePlate = "HIJ012", PricePerDay = 150, IsAvailable = true, Description = "Lightweight and agile roadster with superb handling and a thrilling driving experience.", Seats = 2, CreatedOn = DateTime.UtcNow, ImageUrl = "https://images.drive.com.au/caradvice/image/private/c_fill,f_auto,g_auto,h_1080,q_auto:eco,w_1920/v1/kxbugysymlvq0uexjzag" },
                
                // Porsche cars
                new Car { Model = "Porsche Cayenne", BrandId = 12, CategoryId = 2, Year = 2022, LicensePlate = "NOP678", PricePerDay = 200, IsAvailable = true, Description = "Luxurious and sporty SUV with exceptional performance and handling.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://cdn.motor1.com/images/mgl/Avbvx/s3/2022-porsche-cayenne-coupe-facelift-rendering.jpg" },
                new Car { Model = "Porsche 911", BrandId = 12, CategoryId = 13, Year = 2023, LicensePlate = "QRS901", PricePerDay = 250, IsAvailable = true, Description = "Iconic sports car with timeless design and breathtaking performance.", Seats = 2, CreatedOn = DateTime.UtcNow, ImageUrl = "https://media.ed.edmunds-media.com/porsche/911/2023/oem/2023_porsche_911_coupe_carrera-4-gts_fq_oem_1_1600.jpg" },
                
                // Toyota cars
                new Car { Model = "Toyota Corolla", BrandId = 13, CategoryId = 1, Year = 2021, LicensePlate = "TUV234", PricePerDay = 65, IsAvailable = true, Description = "Reliable and fuel-efficient sedan known for its practicality and low maintenance costs.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.cnet.com/a/img/resize/178a5344de86048c5ccc3552f89c16d9997572cd/hub/2021/01/27/91f27543-bf0c-4440-b6c3-f5bf58f5a3f2/corolla-ogi.jpg?auto=webp&fit=crop&height=675&width=1200" },
                new Car { Model = "Toyota RAV4", BrandId = 13, CategoryId = 2, Year = 2022, LicensePlate = "WXY567", PricePerDay = 85, IsAvailable = true, Description = "Popular compact SUV offering versatility, comfort, and strong resale value.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://sherbrooketoyota.ca/wp-content/uploads/2022/03/Toyota-RAV4-Prime-2022-07.jpg" },
                
                // Tesla cars
                new Car { Model = "Tesla Model 3", BrandId = 14, CategoryId = 7, Year = 2023, LicensePlate = "ZAB890", PricePerDay = 150, IsAvailable = true, Description = "All-electric sedan with long range, rapid acceleration, and advanced technology features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ad/Tesla_Model_3_%282023%29%2C_long_range%2C_Japan%2C_left-front.jpg/1200px-Tesla_Model_3_%282023%29%2C_long_range%2C_Japan%2C_left-front.jpg" },
                new Car { Model = "Tesla Model X", BrandId = 14, CategoryId = 7, Year = 2021, LicensePlate = "CDE012", PricePerDay = 200, IsAvailable = true, Description = "Electric SUV with futuristic design, ample cargo space, and impressive performance.", Seats = 7, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.gaw.to/vehicles/photos/40/25/402549-2021-tesla-model-x.jpg?1024x640" },
                
                // Nissan cars
                new Car { Model = "Nissan Altima", BrandId = 15, CategoryId = 1, Year = 2020, LicensePlate = "EFG345", PricePerDay = 60, IsAvailable = true, Description = "Comfortable and fuel-efficient sedan with a spacious cabin and smooth ride.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://media.ed.edmunds-media.com/nissan/altima/2020/oem/2020_nissan_altima_sedan_25-platinum_fq_oem_1_1600.jpg" },
                new Car { Model = "Nissan Rogue", BrandId = 15, CategoryId = 2, Year = 2022, LicensePlate = "HIJ678", PricePerDay = 80, IsAvailable = true, Description = "Compact SUV offering a comfortable ride, ample cargo space, and user-friendly technology.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.gaw.to/vehicles/photos/40/28/402894-2022-nissan-rogue.jpg?640x400" },
                
                // Suzuki cars
				new Car { Model = "Suzuki Vitara", BrandId = 16, CategoryId = 2, Year = 2023, LicensePlate = "NOP234", PricePerDay = 70, IsAvailable = true, Description = "Compact SUV with rugged styling, comfortable ride, and practical features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://images.drive.com.au/driveau/image/upload/c_fill,f_auto,g_auto,h_1080,q_auto:eco,w_1920/v1/cms/uploads/mbyj2b7ydla4dicwegp5" },
                new Car { Model = "Suzuki Swift", BrandId = 16, CategoryId = 5, Year = 2021, LicensePlate = "KLM901", PricePerDay = 45, IsAvailable = true, Description = "Compact hatchback with agile handling, fuel efficiency, and modern features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://squir.com/media/catalog/product/cache/4709fd52db70e8ed3553f7ffe9d447ff/s/u/suzuki_swift_2021_0000.jpg" },
                
                // Jeep cars
                new Car { Model = "Jeep Wrangler", BrandId = 17, CategoryId = 2, Year = 2020, LicensePlate = "QRS567", PricePerDay = 90, IsAvailable = true, Description = "Iconic off-road SUV with rugged styling and impressive capability on and off the road.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.gaw.to/vehicles/photos/40/20/402068-2020-jeep-wrangler.jpg?1024x640" },
                new Car { Model = "Jeep Grand Cherokee", BrandId = 17, CategoryId = 2, Year = 2021, LicensePlate = "TUV890", PricePerDay = 100, IsAvailable = true, Description = "Full-size SUV offering a comfortable ride, upscale interior, and strong towing capacity.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://cdn.motor1.com/images/mgl/epP9E/s3/jeep-grand-cherokee-rendering.jpg" },
                
                // Ford cars
				new Car { Model = "Ford Explorer", BrandId = 18, CategoryId = 2, Year = 2023, LicensePlate = "ZAB345", PricePerDay = 90, IsAvailable = true, Description = "Popular SUV known for its versatility, comfort, and advanced safety features.", Seats = 7, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.mikemolsteadmotors.com/blogs/4031/wp-content/uploads/2023/10/fordexplorer2023.png" },
                new Car { Model = "Ford Focus", BrandId = 18, CategoryId = 5, Year = 2022, LicensePlate = "WXY012", PricePerDay = 55, IsAvailable = true, Description = "Compact hatchback with nimble handling and a spacious interior.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.autocar.co.uk/sites/autocar.co.uk/files/images/car-reviews/first-drives/legacy/90-ford-focus-2021-refresh-official-images-active-front.jpg" },
                
                // Peugot cars
				new Car { Model = "Peugeot 3008", BrandId = 19, CategoryId = 2, Year = 2020, LicensePlate = "FGH901", PricePerDay = 75, IsAvailable = true, Description = "Award-winning SUV offering comfort, refinement, and practicality.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://images.drive.com.au/driveau/image/upload/c_fill,f_auto,g_auto,h_1080,q_auto:eco,w_1920/v1/cms/uploads/GjaF4aBTXOmsMq0BbGgg" },
                new Car { Model = "Peugeot 206", BrandId = 19, CategoryId = 5, Year = 2021, LicensePlate = "CDE678", PricePerDay = 50, IsAvailable = true, Description = "Stylish and efficient hatchback with a modern interior and enjoyable driving dynamics.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://static1.hotcarsimages.com/wordpress/wp-content/uploads/2021/08/Peugeot-206-1.jpg" },
                
                // Jaguar cars
                new Car { Model = "Jaguar XE", BrandId = 20, CategoryId = 1, Year = 2022, LicensePlate = "IJK234", PricePerDay = 120, IsAvailable = true, Description = "Luxury sedan with dynamic handling, refined interior, and advanced technology.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://images.carexpert.com.au/crop/1200/630/app/uploads/2022/03/2022-Jaguar-XE-HERO.jpg" },
                new Car { Model = "Jaguar F-PACE", BrandId = 20, CategoryId = 2, Year = 2021, LicensePlate = "LMN567", PricePerDay = 140, IsAvailable = true, Description = "Luxurious SUV combining sporty performance with elegance and practicality.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://www.driver.bg/wp-content/uploads/2020/12/jaguar-f-pace-svr-2021-1.jpg" },
                
                // Chevrolet cars
                new Car { Model = "Chevrolet Cruze", BrandId = 21, CategoryId = 1, Year = 2020, LicensePlate = "OPQ890", PricePerDay = 60, IsAvailable = true, Description = "Compact sedan with comfortable ride quality, spacious interior, and good fuel economy.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://i.pinimg.com/736x/99/e1/61/99e161e37cf2c44cc825fccaac98000f.jpg" },
                new Car { Model = "Chevrolet Equinox", BrandId = 21, CategoryId = 2, Year = 2023, LicensePlate = "RST123", PricePerDay = 85, IsAvailable = true, Description = "Compact SUV offering a smooth ride, spacious cabin, and user-friendly features.", Seats = 5, CreatedOn = DateTime.UtcNow, ImageUrl = "https://d2v1gjawtegg5z.cloudfront.net/posts/preview_images/000/014/579/original/2023_Chevy_Equinox.jpeg?1689259049" },
            }); ;

            await context.SaveChangesAsync();
        }
    }
}
