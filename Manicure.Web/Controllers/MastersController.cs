using System.Web.Mvc;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("masters")]
    public class MastersController : Controller
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

        [Route("delete")]
        public ActionResult Delete()
        {
            return RedirectToAction("Get");
        }
    }
}