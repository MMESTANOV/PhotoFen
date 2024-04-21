using PhotoFen.Core.Models.Photographer;

namespace PhotoFen.Core.Models.Photo
{
    public class DetailsPhotoServiceModel : DetailsPhotoViewModel
    {
        public string Description { get; set; } = null!;

        public string Category { get; set; } = null!;

        public PhotographerServiceModel Photographer { get; set; } = null!;
    }
}
