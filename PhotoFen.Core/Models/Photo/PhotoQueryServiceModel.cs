namespace PhotoFen.Core.Models.Photo
{
    public class PhotoQueryServiceModel
    {
        public int TotalPhotosCount { get; set; }

        public IEnumerable<PhotoServiceModel> Photos { get; set; } = new List<PhotoServiceModel>();
    }
}
