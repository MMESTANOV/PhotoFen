using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Infrastructure.Data.Models
{
    [Comment("Photo")]
    public class Photo
    {
        [Key]
        [Comment("Photo Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PhotoTittleMaxLength)]
        [Comment("Photo tittle")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(PhotoDescriptionMaxLength)]
        [Comment("Photo description")]
        public string Description { get; set; } = null!;

        [Required]
        [MaxLength(PhotoMaxValue)]
        [Comment("Photo data")]
        public byte[] PhotoData { get; set; } = null!;

        [Required]
        [Comment("Count of likes on the photo")]
        public int LikesCount { get; set; }

        [Required]
        [Comment("Category identifier")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Comment("Category")]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Date of upload of the photo")]
        public DateTime TimeOfUpload { get; set; }

        [Required]
        [Comment("Photohrapher identifier")]
        public int PhotohrapherId { get; set; }

        [ForeignKey(nameof(PhotohrapherId))]
        [Comment("Photohrapher")]
        public Photographer Photographer { get; set; } = null!;

        [Comment("Comments on this photo")]
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();

        [Comment("Users who liked this photo")]
        public ICollection<IdentityUser> UsersLikedPhotos { get; set; } = new HashSet<IdentityUser>();
    }
}
