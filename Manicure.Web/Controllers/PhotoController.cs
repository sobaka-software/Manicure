using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("photo")]
    public class PhotoController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return View();
        }
    }
}