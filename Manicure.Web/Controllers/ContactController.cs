using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("contact")]
    public class ContactController : Controller
    {
        [Route("")]
        public ActionResult Get()
        {
            return View();
        }
    }
}