using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("shop")]
    public class ShopController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("Main", "Home");
        }
    }
}