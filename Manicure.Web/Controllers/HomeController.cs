using System.Web.Mvc;
using Manicure.Common.Domain;
using Manicure.DataAccess.Context;

namespace Manicure.Web.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Main()
        {
            var a = new ManicureContext();
            a.Clients.Add(new Client());
            a.SaveChanges();
            return View();
        }
    }
}