using Microsoft.AspNetCore.Mvc;
using PhotoFen.Core.Contracts;
using PhotoFen.Core.Models.Photographer;
using PhotoFen.Extensions;
using PhotoGallery.Attributes;

namespace PhotoFen.Controllers
{
    public class PhotographerController : BaseController
    {
        private readonly IPhotographerService photographerService;

        public PhotographerController(IPhotographerService _photographerService)
        {
            photographerService = _photographerService;
        }

        [HttpGet]
        [NotPhotographer]
        public IActionResult Become()
        {

            var model = new BecomePhotographerFormModel();


            return View(model);

        }

        [HttpPost]
        [NotPhotographer]
        public async Task<IActionResult> Become(BecomePhotographerFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }
     

            await photographerService.CreatePhotographerAsync(User.Id(), model.Name, model.PhotographerInfo);

            return RedirectToAction(nameof(HomeController.Index), "Home");

        }

    }
}
