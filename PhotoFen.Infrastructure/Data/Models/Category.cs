using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Infrastructure.Data.Models
{
    [Comment("Photo Category")]
    public class Category
    {
        [Key]
        [Comment("Category Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        [Comment("Category name")]
        public string Name { get; set; } = string.Empty;

        public ICollection<Photo> PhotoGallery { get; set; } = new HashSet<Photo>();
    }
}
