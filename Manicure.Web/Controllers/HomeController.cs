using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Main()
        {
            return View();
        }
    }
}