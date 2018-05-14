using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Main()
        {
            return View();
        }
    }
}