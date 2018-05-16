using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Dtos;
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
            var procedureToAdd = Mapper.Map<ProcedureEntryViewModel, ProcedureDto>(procedure);

            procedureToAdd.ClientLogin = User.Identity.Name;

            _procedureService.Add(procedureToAdd);

            return RedirectToAction("Main", "Home");
        }
    }
}