using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("price")]
    public class PriceController : Controller
    {
        [Route("")]
        public ActionResult Get()
        {
            return View();
        }

        [Route("add")]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public ActionResult Add(string stub)
        {
            return View();
        }

        [Route("update")]
        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [Route("update")]
        [HttpPost]
        public ActionResult Update(string stub)
        {
            return View();
        }
    }
}