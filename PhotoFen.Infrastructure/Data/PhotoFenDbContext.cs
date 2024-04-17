using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhotoFen.Infrastructure.Data.Models;
using PhotoFen.Infrastructure.Data.SeedDB;

namespace PhotoFen.Data
{
     public class PhotoFenDbContext : IdentityDbContext
     {
          public PhotoFenDbContext(DbContextOptions<PhotoFenDbContext> options)
              : base(options)
          {
          }

          protected override void OnModelCreating(ModelBuilder builder)
          {

              builder.ApplyConfiguration(new UserConfiguration());
              builder.ApplyConfiguration(new PhotographerConfiguration());
              builder.ApplyConfiguration(new CategoryConfiguration());

              base.OnModelCreating(builder);
          }

          public DbSet<Photographer> Photographers { get; set; } = null!;
          public DbSet<Category> Categories { get; set; } = null!;
          public DbSet<Photo> Photos { get; set; } = null!;
          public DbSet<Comment> Comments { get; set; } = null!;
          public DbSet<Publication> Publications { get; set; } = null!;

     }
    
}
