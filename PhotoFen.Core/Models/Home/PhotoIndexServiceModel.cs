using PhotoFen.Core.Contracts;

namespace PhotoFen.Core.Models.Home
{
    public class PhotoIndexServiceModel: IPhotoModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
