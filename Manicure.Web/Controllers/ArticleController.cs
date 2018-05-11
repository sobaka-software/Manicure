using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("article")]
    public class ArticleController : Controller
    {
        [Route("")]
        public ActionResult Get()
        {
            return View();
        }
    }
}