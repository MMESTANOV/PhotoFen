using PhotoFen.Infrastructure.Data.Models;

namespace PhotoFen.Core.Models.Photo
{
    public class DetailsPhotoViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public byte[] PhotoData { get; set; } = null!;
        public int LikesCount { get; set; }
        public int CategoryId { get; set; }
        public string TimeOfUpload { get; set; } = null!;
        public int PhotohrapherId { get; set; }
        public List<Comment> Comments { get; set; } = null!;

    }
}
