using PhotoFen.Core.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static PhotoFen.Core.Constants.MessagesConstants;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Core.Models.Photo
{
    public class PhotoServiceModel : IPhotoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhotoTittleMaxLength,
            MinimumLength = PhotoTittleMinLength,
            ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhotoDescriptionMaxLength,
            MinimumLength = PhotoDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        public string PhotoData { get; set; } = null!;
    }
}
