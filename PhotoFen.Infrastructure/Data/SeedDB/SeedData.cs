using Microsoft.AspNetCore.Identity;
using PhotoFen.Infrastructure.Data.Models;

namespace PhotoFen.Infrastructure.Data.SeedDB
{
    internal class SeedData
    {
        public IdentityUser PhotographerUser1 { get; set; }
        public IdentityUser PhotographerUser2 { get; set; }

        public IdentityUser GuestUser { get; set; }

        public Photographer Photographer1 { get; set; }
        public Photographer Photographer2 { get; set; }

        public Category LandscapesCategory { get; set; }
        public Category AnimalsCategory { get; set; }
        public Category MacroCategory { get; set; }
        public Category PeopleCategory { get; set; }
        public Category TravelCategory { get; set; }
        public Category StreetCategory { get; set; }
        public Category SportCategory { get; set; }
        public Category OtherCategory { get; set; }

        public Photo Photo1 { get; set; }
        public Photo Photo2 { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedPhotographers();
            SeedCategories();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            PhotographerUser1 = new IdentityUser()
            {
                Id = "met12856-c198-4120-b3z3-b893d8396482",
                UserName = "photographer1@mail.com",
                NormalizedUserName = "photographer1@mail.com",
                Email = "photographer1@mail.com",
                NormalizedEmail = "photographer1@mail.com"
            };

            PhotographerUser1.PasswordHash =
                 hasher.HashPassword(PhotographerUser1, "photographer10000");


            PhotographerUser2 = new IdentityUser()
            {
                Id = "taa11559-c198-4129-b3f3-b893d8395083",
                UserName = "photographer2@mail.com",
                NormalizedUserName = "photographer2@mail.com",
                Email = "photographer2@mail.com",
                NormalizedEmail = "photographer2@mail.com"
            };

            PhotographerUser2.PasswordHash =
                 hasher.HashPassword(PhotographerUser2, "photographer20000");

            GuestUser = new IdentityUser()
            {
                Id = "6o5803ce-d744-4fc8-83d9-d6b3ac1f591k",
                UserName = "guest2024@mail.com",
                NormalizedUserName = "guest2024@mail.com",
                Email = "guest2024@mail.com",
                NormalizedEmail = "guest2024@mail.com"
            };

            GuestUser.PasswordHash =
                 hasher.HashPassword(GuestUser, "guest0000");

        }
        private void SeedPhotographers()
        {
            Photographer1 = new Photographer()
            {
                Id = 1,
                Name = "Petrov",
                PhotographerInfo = "I am Petar Petrov from Bulgaria and i shooting  landscapes.",
                UserId = PhotographerUser1.Id

            };

            Photographer2 = new Photographer()
            {
                Id = 2,
                Name = "Macro Shooter",
                PhotographerInfo = "I'm Stan from the Czech Republic. I love macro photography.",
                UserId = PhotographerUser2.Id
            };
        }
        private void SeedCategories()
        {
            LandscapesCategory = new Category()
            {
                Id = 1,
                Name = "Landscapes"
            };

            AnimalsCategory = new Category()
            {
                Id = 2,
                Name = "Animals"
            };

            MacroCategory = new Category()
            {
                Id = 3,
                Name = "Macro"
            };

            PeopleCategory = new Category()
            {
                Id = 4,
                Name = "People"
            };

            TravelCategory = new Category()
            {
                Id = 5,
                Name = "Travel"
            };

            StreetCategory = new Category()
            {
                Id = 6,
                Name = "Street"
            };

            SportCategory = new Category()
            {
                Id = 7,
                Name = "Sport"
            };

            OtherCategory = new Category()
            {
                Id = 8,
                Name = "Other"
            };
        }
    }
}
