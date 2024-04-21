using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoFen.Core.Contracts;
using PhotoFen.Core.Extensions;
using PhotoFen.Core.Models.Home;
using PhotoFen.Core.Models.Photo;
using PhotoFen.Core.Services;
using PhotoFen.Extensions;

namespace PhotoFen.Controllers
{
    public class PhotoController : BaseController
    {
        private readonly IPhotoService photoService;

        private readonly IPhotographerService photographerService;

        private readonly ILogger logger;

        public PhotoController(
            IPhotoService _photoService,
            IPhotographerService _photographerService,
            ILogger<PhotoController> _logger)
        {
            photoService = _photoService;
            photographerService = _photographerService;
            logger = _logger;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllPhotosQueryModel model)
        {
            var photos = await photoService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.PhotosPerPage);

            model.TotalPhotosCount = photos.TotalPhotosCount;
            model.Photos = photos.Photos;
            model.Categories = await photoService.AllCategoriesNamesAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();

            IEnumerable<PhotoServiceModel> model;

           
            int photographerId = await photographerService.GetPhotographerIdAsync(userId) ?? 0;
            model = await photoService.AllPhotosByPhotographerIdAsync(photographerId);
          

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await photoService.ExistsPhotoAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await photoService.PhotoDetailsByIdAsync(id);


            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Best() 
        {
            IEnumerable<PhotoIndexServiceModel> model;
            model = await photoService.BestThreePhotosAsync();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if ((await photographerService.ExistsPhotographerByIdAsync(User.Id())) == false)
            {
                return RedirectToAction(nameof(PhotographerController.Become), "Photographer");
            }

            var model = new AddPhotoFormModel()
            {
                Categories = await photoService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPhotoFormModel model)
        {
            if ((await photographerService.ExistsPhotographerByIdAsync(User.Id())) == false)
            {
                return RedirectToAction(nameof(PhotographerController.Become), "Photographer");
            }

            if ((await photoService.CategoryExistsAsync(model.CategoryId)) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exists");
            }

            //if (!ModelState.IsValid)
            //{
            //    model.Categories = await photoService.AllCategoriesAsync();

            //    return View(model);
            //}


            int? photographerId = await photographerService.GetPhotographerIdAsync(User.Id());

            int newPhotoId = await photoService.AdPhotoAsync(model, photographerId ?? 0);


            return RedirectToAction(nameof(Mine));
        }
    }
}
