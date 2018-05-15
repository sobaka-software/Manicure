using System.Web.Mvc;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("procedure")]
    public class ProcedureController : Controller
    {
        private readonly IProcedureService _procedureService;

        public ProcedureController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(ProcedureEntryViewModel procedure)
        {
            return RedirectToAction("Main", "Home");
        }
    }
}