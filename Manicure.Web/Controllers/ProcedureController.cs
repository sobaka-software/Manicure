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
        private readonly IMasterService _masterService;

        public ProcedureController(IProcedureService procedureService, IMasterService masterService)
        {
            _procedureService = procedureService;
            _masterService = masterService;
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(ProcedureEntryViewModel procedure)
        {
            var master = _masterService.GetBy(procedure.MasterId);
            var requestedProcedure = _procedureService.Get().FirstOrDefault(p => p.ProcedureId == procedure.ProcedureId);
            var requestedProcedureTimeStart = (procedure.Date + procedure.StartTime.TimeOfDay).TimeOfDay;
            var requestedProcedureTimeEnd = (procedure.Date + procedure.StartTime.AddHours(requestedProcedure.Duration).TimeOfDay).TimeOfDay;

            if (procedure.Date + procedure.StartTime.TimeOfDay < DateTime.Now)
            {
                TempData["Message"] = "Выберите дату и время не раньше текущей";

                return RedirectToAction("Main", "Home");
            }

            var procedureEntries = new List<ProcedureEntry>();
            procedureEntries.AddRange(
                master.Schedules.SelectMany(a => a.ProcedureEntries));

            var procedures = procedureEntries.Select(d => d.Schedule);

            foreach (var masterProcedure in procedures)
            {
                var procedureTimeStart = (masterProcedure.Date + masterProcedure.StartTime.TimeOfDay).TimeOfDay;

                var procedureTimeEnd = (masterProcedure.Date + masterProcedure.EndTime.TimeOfDay).TimeOfDay;

                if (masterProcedure.Date.Date == procedure.Date.Date &&
                    requestedProcedureTimeStart >= procedureTimeStart && requestedProcedureTimeStart <= procedureTimeEnd &&
                    requestedProcedureTimeEnd >= procedureTimeStart && requestedProcedureTimeEnd >= procedureTimeEnd)
                {
                    TempData["Message"] = "Мастер занят в это время, вы можете просмотреть <a id='modal'>его расписание</a>";

                    TempData["MasterSchedule"] = master.Schedules.Where(s => s.Date.Date == procedure.Date.Date);

                    return RedirectToAction("Main", "Home");
                }
            }

            var procedureToAdd = Mapper.Map<ProcedureEntryViewModel, ProcedureDto>(procedure);

            procedureToAdd.ClientLogin = User.Identity.Name;

            _procedureService.Add(procedureToAdd);

            TempData["Message"] = "Ваша запись принята";

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