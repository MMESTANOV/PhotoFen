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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await photoService.ExistsPhotoAsync(id) == false)
            {
                return BadRequest();
            }

            if (await photoService.HasPhotographerWithIdAsync(id, User.Id()) == false
                /*&& User.IsAdmin() == false*/)
            {
                return Unauthorized();
            }

            var model = await photoService.GetPhotoFormModelByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddPhotoFormModel model)
        {
            if (await photoService.ExistsPhotoAsync(id) == false)
            {
                return BadRequest();
            }

            if (await photoService.HasPhotographerWithIdAsync(id, User.Id()) == false
                /*&& User.IsAdmin() == false*/)
            {
                return Unauthorized();
            }

            if (await photoService.CategoryExistsAsync(model.CategoryId) == false)
            {
                ModelState.AddModelError(nameof(model.CategoryId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                model.Categories = await photoService.AllCategoriesAsync();

                return View(model);
            }

            await photoService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await photoService.ExistsPhotoAsync(id) == false)
            {
                return BadRequest();
            }

            if (await photoService.HasPhotographerWithIdAsync(id, User.Id()) == false
                /*&& User.IsAdmin() == false*/)
            {
                return Unauthorized();
            }

            var photo = await photoService.PhotoDetailsByIdAsync(id);

            var model = new DetailsPhotoViewModel()
            {
                Id = id,
                Description = photo.Description,
                TimeOfUpload = photo.TimeOfUpload,
                Title = photo.Title,
                PhotoData = photo.PhotoData,
                CategoryId = photo.CategoryId,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DetailsPhotoViewModel model)
        {
            if (await photoService.ExistsPhotoAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await photoService.HasPhotographerWithIdAsync(model.Id, User.Id()) == false
                /*&& User.IsAdmin() == false*/)
            {
                return Unauthorized();
            }

            await photoService.DeleteAsync(model.Id);

            return RedirectToAction(nameof(All));
        }

    }
}
