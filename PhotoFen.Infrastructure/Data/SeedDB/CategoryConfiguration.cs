using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoFen.Infrastructure.Data.Models;

namespace PhotoFen.Infrastructure.Data.SeedDB
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[]
            {
                data.LandscapesCategory,
                data.MacroCategory,
                data.PeopleCategory,
                data.TravelCategory,
                data.StreetCategory,
                data.SportCategory,
                data.OtherCategory
            });
        }
    }
}
