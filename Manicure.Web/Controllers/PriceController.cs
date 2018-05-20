using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("price")]
    public class PriceController : Controller
    {
        private readonly IProcedureService _procedureService;

        public PriceController(IProcedureService procedureService)
        {
            _procedureService = procedureService;
        }

        [Route("")]
        [HttpGet]
        public ActionResult Get()
        {
            var procedures = _procedureService.Get();

            var proceduresToShow = Mapper.Map<IEnumerable<Procedure>, IEnumerable<ProcedureViewModel>>(procedures);

            return View(proceduresToShow);
        }

        [Route("update")]
        [HttpPost]
        [Authorize(Roles = "Master,Administrator")]
        public ActionResult Update(ProcedureViewModel procedure)
        {
            var procedureToAdd = Mapper.Map<ProcedureViewModel, Procedure>(procedure);

            _procedureService.Update(procedureToAdd);

            return RedirectToAction("Get");
        }

        [Route("delete")]
        [HttpGet]
        [Authorize(Roles = "Master,Administrator")]
        public ActionResult Delete(int id)
        {
            _procedureService.Delete(id);

            return RedirectToAction("Get");
        }
    }
}