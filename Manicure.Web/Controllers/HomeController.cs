using System.Web.Mvc;
using Manicure.BusinessLogic.Authentication;

namespace Manicure.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public HomeController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [Route("")]
        public ActionResult Main()
        {
            return View();
        }
    }
}