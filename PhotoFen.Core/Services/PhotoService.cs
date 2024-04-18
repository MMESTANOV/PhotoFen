using Microsoft.EntityFrameworkCore;
using PhotoFen.Core.Contracts;
using PhotoFen.Core.Enumerations;
using PhotoFen.Core.Models.Home;
using PhotoFen.Core.Models.Photo;
using PhotoFen.Infrastructure.Data.Common;
using PhotoFen.Infrastructure.Data.Models;

namespace PhotoFen.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository repository;

        public PhotoService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int> AdPhotoAsync(AddPhotoFormModel model, int photographerId)
        {
            Photo newPhoto = new Photo()
            {
                Title = model.Title,
                Description = model.Description,
                TimeOfUpload = DateTime.Now,
                PhotoData = model.PhotoData,
                PhotohrapherId = photographerId,
                CategoryId = model.CategoryId
            };

            await repository.AddAsync(newPhoto);
            await repository.SaveChangesAsync();

            return newPhoto.Id;
        }

        public async Task<PhotoQueryServiceModel> AllAsync(
            string? category = null,
            string? searchTerm = null,
            PhotoSorting sorting = PhotoSorting.Newest,
            int currentPage = 1,
            int photosPerPage = 1)
        {
            var photosToShow = repository.AllReadOnly<Photo>();

            if (category != null)
            {
                photosToShow = photosToShow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                photosToShow = photosToShow
                    .Where(h => (h.Title.ToLower().Contains(normalizedSearchTerm) ||
                                h.Description.ToLower().Contains(normalizedSearchTerm)));
            }

            photosToShow = sorting switch
            {
                PhotoSorting.Newest => photosToShow
                    .OrderByDescending(p => p.TimeOfUpload),
                PhotoSorting.Oldest => photosToShow
                    .OrderBy(p => p.TimeOfUpload),
                PhotoSorting.NumberOfLikes => photosToShow
                    .OrderByDescending(p => p.LikesCount)
            };

            var photos = await photosToShow
                .Skip((currentPage - 1) * photosPerPage)
                .Take(photosPerPage)
                .ProjectToPhotoServiceModel()
                .ToListAsync();

            int totalPhotos = await photosToShow.CountAsync();

            return new PhotoQueryServiceModel()
            {
                Photos = photos,
                TotalPhotosCount = totalPhotos
            };
        }

        public async Task<IEnumerable<PhotoCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new PhotoCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<PhotoServiceModel>> AllPhotosByPhotographerIdAsync(int photographerId)
        {
            return await repository.AllReadOnly<Photo>()
               .Where(h => h.PhotohrapherId == photographerId)
               .ProjectToPhotoServiceModel()
               .ToListAsync();
        }

        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                 .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<PhotoIndexServiceModel>> BestThreePhotosAsync()
        {
            return await repository
                 .AllReadOnly<Photo>()
                 .OrderByDescending(p => p.LikesCount)
                 .Take(3)
                 .Select(h => new PhotoIndexServiceModel()
                 {
                     Id = h.Id,
                     Description = h.Description
                 })
                 .ToListAsync();
        }

        public async Task<bool> HasPhotographerWithIdAsync(int photoId, string userId)
        {
            return await repository.AllReadOnly<Photo>()
                .AnyAsync(h => h.Id == photoId && h.Photographer.UserId == userId);
        }

        public async Task<bool> ExistsPhotoAsync(int id)
        {
            return await repository.AllReadOnly<Photo>()
                .AnyAsync(h => h.Id == id);
        }
        public Task<DetailsPhotoServiceModel> PhotoDetailsByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int photoId, AddPhotoFormModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int photoId)
        {
            throw new NotImplementedException();
        }




        public static byte[] FileToByteArray(string fileName)
        {
            byte[] photoData;

            using (FileStream fs = File.OpenRead(fileName))
            {
                var binaryReader = new BinaryReader(fs);
                photoData = binaryReader.ReadBytes((int)fs.Length);
            }
            return photoData;
        }
    }
}