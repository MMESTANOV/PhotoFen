using PhotoFen.Core.Models.Photo;
using PhotoFen.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableHouseExtension
    {
        public static IQueryable<PhotoServiceModel> ProjectToPhotoServiceModel(this IQueryable<Photo> photos)
        {
            return photos
                .Select(p => new PhotoServiceModel()
                {
                    Id = p.Id,
                    Title = p.Title, 
                    Description = p.Description
                });
        }
    }
}