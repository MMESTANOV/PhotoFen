using PhotoFen.Core.Enumerations;
using PhotoFen.Core.Models.Home;
using PhotoFen.Core.Models.Photo;

namespace PhotoFen.Core.Contracts
{
    public interface IPhotoService
    {
        Task<PhotoQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            PhotoSorting sorting = PhotoSorting.Newest,
            int currentPage = 1,
            int photosPerPage = 1
            );

        Task<IEnumerable<PhotoIndexServiceModel>> BestThreePhotosAsync();

        Task<IEnumerable<PhotoCategoryServiceModel>> AllCategoriesAsync();

        Task<IEnumerable<string>> AllCategoriesNamesAsync();

        Task<bool> CategoryExistsAsync(int categoryId);

        Task<int> AdPhotoAsync(AddPhotoFormModel model, int photographerId);

        Task<bool> ExistsPhotoAsync(int id);

        Task<IEnumerable<PhotoServiceModel>> AllPhotosByPhotographerIdAsync(int photographerId);

        Task<DetailsPhotoServiceModel> PhotoDetailsByIdAsync(int id);

        Task<bool> HasPhotographerWithIdAsync(int photoId, string userId);

        Task EditAsync(int photoId, AddPhotoFormModel model);

        Task DeleteAsync(int photoId);
    }

}
