using PhotoFen.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PhotoFen.Core.Models.Photo
{
    public class AllPhotosQueryModel
    {
        public int PhotosPerPage { get; } = 3;

        public string Category { get; init; } = null!;

        [Display(Name = "Search by text")]
        public string SearchTerm { get; init; } = null!;

        public PhotoSorting Sorting { get; init; }

        public int CurrentPage { get; init; } = 1;

        public int TotalPhotosCount { get; set; }

        public IEnumerable<string> Categories { get; set; } = null!;

        public IEnumerable<PhotoServiceModel> Photos { get; set; } = new List<PhotoServiceModel>();
    }
}
