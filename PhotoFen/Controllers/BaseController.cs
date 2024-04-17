using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PhotoFen.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
