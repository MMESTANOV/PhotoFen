using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Infrastructure.Data.Models
{
    [Comment("Publication")]
    public class Publication
    {
        [Key]
        [Comment("Publication Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(PublicationTittleMaxLength)]
        [Comment("Publication tittle")]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(PublicationContentMaxLength)]
        [Comment("Publication content")]
        public string Content { get; set; } = null!;

        [Required]
        [Comment("Date of posted of the publication")]
        public DateTime CreatedOn { get; set; }
    }
}
