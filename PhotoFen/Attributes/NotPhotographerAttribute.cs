using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using PhotoFen.Core.Contracts;
using PhotoFen.Extensions;

namespace PhotoGallery.Attributes
{
    public class NotPhotographerAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IPhotographerService? photographerService = context.HttpContext.RequestServices.GetService<IPhotographerService>();

            if (photographerService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (photographerService != null && photographerService.ExistsPhotographerByIdAsync(context.HttpContext.User.Id()).Result)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }
    }
}
