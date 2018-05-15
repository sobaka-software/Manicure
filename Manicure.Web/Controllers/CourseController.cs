using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("course")]
    public class CourseController : Controller
    {
        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            return View();
        }
    }
}