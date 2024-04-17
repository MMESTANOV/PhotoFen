using System.ComponentModel.DataAnnotations;

namespace PhotoFen.Core.Models.Photographer
{
    public class PhotographerServiceModel
    {
        [Display(Name = "Photographer name")]
        public string Name { get; set; } = null!;

    }
}
