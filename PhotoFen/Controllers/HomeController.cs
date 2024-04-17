using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoFen.Core.Contracts;

namespace PhotoFen.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPhotoService photoService;

        public HomeController(ILogger<HomeController> logger, IPhotoService _photoService)
        {
            _logger = logger;
            photoService = _photoService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var model = await photoService.BestThreePhotosAsync();

            return View(model);
        }

        [AllowAnonymous]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {

            if (statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 500)
            {
                return View("Error500");
            }

            return View();
        }
    }
}
