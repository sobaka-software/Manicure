using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }
    }
}