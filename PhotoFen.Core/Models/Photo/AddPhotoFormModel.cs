using Microsoft.AspNetCore.Http;
using PhotoFen.Core.Contracts;
using PhotoFen.Core.Extensions;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [DisplayName("Photo data")]
        public string PhotoData { get; set; } = null!;


        [Required]
        public int CategoryId { get; set; }

        public IEnumerable<PhotoCategoryServiceModel> Categories { get; set; } = new List<PhotoCategoryServiceModel>();

        [NotMapped]
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        [MaxFileSize(2 * 1024 * 1024)]
        public IFormFile ImageFile { get; set; } = null!;
    }
}
