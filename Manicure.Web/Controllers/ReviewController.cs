using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("review")]
    public class ReviewController : Controller
    {
        [Route("")]
        public ActionResult Get()
        {
            return View();
        }
    }
}