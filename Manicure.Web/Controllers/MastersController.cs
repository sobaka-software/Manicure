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

        [HttpGet]
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
    }
}