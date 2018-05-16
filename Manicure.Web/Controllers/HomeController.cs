using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProcedureService _procedureService;
        private readonly IMasterService _masterService;

        public HomeController(IProcedureService procedureService, IMasterService masterService)
        {
            _procedureService = procedureService;
            _masterService = masterService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Main()
        {
            var controls = new ControlDataViewModel
            {
                MastersList = MakeMastersList(),
                ProceduresList = MakeProceduresList()
            };

            return View(controls);
        }

        private SelectList MakeProceduresList()
        {
            var procedures = _procedureService.Get().ToList();
            procedures.Insert(0, new Procedure
            {
                ProcedureName = "Выберите процедуру"
            });
            var proceduresList = new SelectList(procedures, "ProcedureId", "ProcedureName");

            return proceduresList;
        }

        private SelectList MakeMastersList()
        {
            var masters = _masterService.GetAll().ToList();

            var mastersList = masters.Select(master => new SelectListItem { Value = master.MasterId.ToString(), Text = master.User.FirstName + " " + master.User.LastName }).ToList();

            mastersList.Insert(0, new SelectListItem { Value = "0", Text = "Выберите мастера" });

            return new SelectList(mastersList, "Value", "Text");
        }
    }
}