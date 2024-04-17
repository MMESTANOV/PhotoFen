using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PhotoFen.Infrastructure.Data.SeedDB
{
    internal class UserConfiguration : IEntityTypeConfiguration<IdentityUser>
    {
        public void Configure(EntityTypeBuilder<IdentityUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new IdentityUser[] { data.PhotographerUser1, data.PhotographerUser2, data.GuestUser });
        }
    }
}
