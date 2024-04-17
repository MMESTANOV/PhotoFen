using PhotoFen.Core.Contracts;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static PhotoFen.Core.Constants.MessagesConstants;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Core.Models.Photo
{
    public class AddPhotoFormModel : IPhotoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhotoTittleMaxLength, MinimumLength = PhotoTittleMinLength, ErrorMessage = LengthMessage)]
        [DisplayName("Photo tittle")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhotoDescriptionMaxLength, MinimumLength = PhotoDescriptionMinLength, ErrorMessage = LengthMessage)]
        [DisplayName("Photo description")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PhotoMinValue, PhotoMaxValue)]
        [DisplayName("Photo data")]
        public byte[] PhotoData { get; set; } = null!;


        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<PhotoCategoryServiceModel> Categories { get; set; } = new List<PhotoCategoryServiceModel>();
    }
}
