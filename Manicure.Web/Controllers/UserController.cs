using System.Web.Mvc;
using Manicure.BusinessLogic.Authentication;
using Manicure.Common.Auth;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public UserController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(Login login)
        {
            _authProvider.Authenticate(login);

            return RedirectToAction("Main", "Home");
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