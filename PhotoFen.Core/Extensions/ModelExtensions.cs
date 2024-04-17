using PhotoFen.Core.Contracts;
using System.Text.RegularExpressions;

namespace PhotoFen.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IPhotoModel photo)
        {
            string info = photo.Title + photo.Description;
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }

    }
}
