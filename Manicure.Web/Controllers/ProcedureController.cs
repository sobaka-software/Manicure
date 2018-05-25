using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Dtos;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("procedure")]
    public class ProcedureController : Controller
    {
        private readonly IProcedureService _procedureService;
        private readonly IUserService _userService;
        private readonly IMasterService _masterService;

        public ProcedureController(IProcedureService procedureService, IUserService userService, IMasterService masterService)
        {
            _procedureService = procedureService;
            _userService = userService;
            _masterService = masterService;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(ProcedureEntryViewModel procedure)
        {
            var master = _masterService.GetBy(procedure.MasterId);

            var procedureDateTime = procedure.Date + procedure.StartTime.TimeOfDay;

            var procedureEntries = new List<ProcedureEntry>();
            procedureEntries.AddRange(
                master.Schedules.SelectMany(a => a.ProcedureEntries));

            var procedures = procedureEntries.Select(d => d.Schedule);

            var dateBefore = procedureEntries.Where(p => p.Schedule.Date == procedure.Date && p.Schedule.== procedure.Date)

            foreach (var masterProcedure in procedures)
            {
                var procedureDateTimeStart = masterProcedure.Date + masterProcedure.StartTime.TimeOfDay;

                var procedureDateTimeEnd = masterProcedure.Date + masterProcedure.EndTime.TimeOfDay;
                
                if (procedureDateTime >= procedureDateTimeStart && procedureDateTime <= procedureDateTimeEnd)
                {
                    TempData["Message"] = "Мастер занят в это время";

                    return RedirectToAction("Main", "Home");
                }
            }

            var procedureToAdd = Mapper.Map<ProcedureEntryViewModel, ProcedureDto>(procedure);
            
            procedureToAdd.ClientLogin = User.Identity.Name;

            _procedureService.Add(procedureToAdd);

            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            _procedureService.Delete(id);

            return RedirectToAction("UserProfile", "User");
        }
    }
}