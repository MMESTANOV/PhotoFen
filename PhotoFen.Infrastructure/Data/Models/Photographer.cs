using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Infrastructure.Data.Models
{
    [Comment("Photographer")]
    public class Photographer
    {
        [Key]
        [Comment("Photographer Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PhotographerNameMaxLength)]
        [Comment("Photographer name")]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(PhotographerDescriptionMaxLength)]
        [Comment("Photographer info")]
        public string PhotographerInfo { get; set; } = null!;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        [Comment("User")]
        public IdentityUser User { get; set; } = null!;

        [Comment("Photo collection")]
        public ICollection<Photo> PhotoGallery { get; set; } = new HashSet<Photo>();
    }
}
