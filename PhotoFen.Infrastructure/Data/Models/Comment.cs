using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Infrastructure.Data.Models
{
    [Comment("Photo Comment")]
    public class Comment
    {
        [Key]
        [Comment("Comment Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CommentContentMaxLength)]
        [Comment("Comment content")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("User Identifier")]
        public string UserID { get; set; } = null!;

        [ForeignKey(nameof(UserID))]
        [Comment("User")]
        public IdentityUser User { get; set; } = null!;

        [Required]
        [Comment("Date of posted of the comment")]
        public DateTime CreatedOn { get; set; }

    }
}
