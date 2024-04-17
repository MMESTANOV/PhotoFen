using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhotoFen.Controllers;
using PhotoFen.Core.Contracts;
using PhotoFen.Extensions;

namespace PhotoGallery.Attributes
{
    public class MustBePhotographerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IPhotographerService? photographerService = context.HttpContext.RequestServices.GetService<IPhotographerService>();

            if (photographerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (photographerService != null && photographerService.ExistsPhotographerByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(PhotographerController.Become), "Photographer", null);
            }
        }
    }
}
