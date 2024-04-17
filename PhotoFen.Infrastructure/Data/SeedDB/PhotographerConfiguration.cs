using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhotoFen.Infrastructure.Data.Models;

namespace PhotoFen.Infrastructure.Data.SeedDB
{
    internal class PhotographerConfiguration : IEntityTypeConfiguration<Photographer>
    {
        public void Configure(EntityTypeBuilder<Photographer> builder)
        {
            var data = new SeedData();

            builder.HasData(new Photographer[] { data.Photographer1, data.Photographer2 });
        }
    }
}
