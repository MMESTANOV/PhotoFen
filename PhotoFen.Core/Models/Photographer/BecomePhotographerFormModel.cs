using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using static PhotoFen.Core.Constants.MessagesConstants;
using static PhotoFen.Infrastructure.Data.Constants.DataConstants;

namespace PhotoFen.Core.Models.Photographer
{
    public class BecomePhotographerFormModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhotographerNameMaxLength,
            MinimumLength = PhotographerNameMinLength,
            ErrorMessage = LengthMessage)]
        [DisplayName("Photographer Name")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhotographerDescriptionMaxLength,
            MinimumLength = PhotographerDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        [DisplayName("Photographer Info")]
        public string PhotographerInfo { get; set; } = null!;
    }
}
