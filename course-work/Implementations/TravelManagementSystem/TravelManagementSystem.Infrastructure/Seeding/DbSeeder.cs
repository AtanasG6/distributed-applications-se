using TravelManagementSystem.Application.Helpers;
using TravelManagementSystem.Domain.Entities;
using TravelManagementSystem.Infrastructure.Persistence;

namespace TravelManagementSystem.Infrastructure.Seeding
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Username = "admin",
                    Email = "admin@tms.com",
                    PasswordHash = PasswordHelper.HashPassword("admin123"),
                    Role = "Admin",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    PhoneNumber = "0888123456",
                    CreatedOn = DateTime.UtcNow
                };

                var user = new User
                {
                    Username = "user1",
                    Email = "user1@tms.com",
                    PasswordHash = PasswordHelper.HashPassword("user123"),
                    Role = "User",
                    DateOfBirth = new DateTime(1995, 5, 10),
                    PhoneNumber = "0888123457",
                    CreatedOn = DateTime.UtcNow
                };

                context.Users.AddRange(admin, user);
                context.SaveChanges();
            }

            var creatorId = context.Users.First().Id;

            if (!context.Destinations.Any())
            {
                var destinations = new List<Destination>
                {
                    new Destination
                    {
                        Country = "Italy",
                        City = "Rome",
                        Description = "Historical capital with ancient ruins.",
                        Latitude = 41.9028,
                        Longitude = 12.4964,
                        CreatedById = creatorId,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Destination
                    {
                        Country = "France",
                        City = "Paris",
                        Description = "The romantic capital of Europe.",
                        Latitude = 48.8566,
                        Longitude = 2.3522,
                        CreatedById = creatorId,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Destination
                    {
                        Country = "Japan",
                        City = "Kyoto",
                        Description = "A city full of temples and tradition.",
                        Latitude = 35.0116,
                        Longitude = 135.7681,
                        CreatedById = creatorId,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Destination
                    {
                        Country = "USA",
                        City = "New York",
                        Description = "The city that never sleeps.",
                        Latitude = 40.7128,
                        Longitude = -74.0060,
                        CreatedById = creatorId,
                        CreatedOn = DateTime.UtcNow
                    },
                    new Destination
                    {
                        Country = "Brazil",
                        City = "Rio de Janeiro",
                        Description = "Famous for beaches, carnival and Christ the Redeemer.",
                        Latitude = -22.9068,
                        Longitude = -43.1729,
                        CreatedById = creatorId,
                        CreatedOn = DateTime.UtcNow
                    }
                };

                context.Destinations.AddRange(destinations);
                context.SaveChanges();
            }

            var romeDestinationId = context.Destinations
                .FirstOrDefault(d => d.City == "Rome" && d.Country == "Italy")?.Id ?? 1;

            if (!context.Trips.Any())
            {
                var trip = new Trip
                {
                    Title = "Spring Vacation in Rome",
                    DestinationId = romeDestinationId,
                    StartDate = new DateTime(2025, 4, 10),
                    EndDate = new DateTime(2025, 4, 17),
                    Price = 850.00m,
                    CreatedById = creatorId,
                    CreatedOn = DateTime.UtcNow
                };

                context.Trips.Add(trip);
                context.SaveChanges();
            }
        }
    }
}
