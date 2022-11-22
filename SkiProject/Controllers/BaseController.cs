using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SkiProject.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
       //public override OnActionExecuted
    }
}
