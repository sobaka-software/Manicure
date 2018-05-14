using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("masters")]
    public class MastersController : Controller
    {
        private readonly IMasterService _masterService;
        private readonly IUserService _userService;

        public MastersController(IMasterService masterService, IUserService userService)
        {
            _masterService = masterService;
            _userService = userService;
        }

        [Route("")]
        public ActionResult Get()
        {
            var users = _userService.GetBy("Master");
            var masters = _masterService.GetAll();

            var mastersToShow = Mapper.Map<IEnumerable<User>, IEnumerable<MasterToViewViewModel>>(users);

            foreach (var masterToShow in mastersToShow)
            {
                var master = masters.FirstOrDefault(u => u.User.UserId == masterToShow.UserId);
                masterToShow.Description = master.Description;
                masterToShow.Photo = master.Photo;
            }

            return View(mastersToShow);
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