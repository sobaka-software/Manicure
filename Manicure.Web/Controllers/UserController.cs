using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(string id)
        {
            return View();
        }

        [HttpGet]
        [Route("register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(string id)
        {
            return View();
        }
    }
}