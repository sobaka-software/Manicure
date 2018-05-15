using System;
using System.IO;
using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Authentication;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Auth;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        private readonly IAuthProvider _authProvider;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IMasterService _masterService;

        public UserController(
            IAuthProvider authProvider, 
            IUserService userService, 
            IClientService clientService, 
            IMasterService masterService)
        {
            _authProvider = authProvider;
            _userService = userService;
            _clientService = clientService;
            _masterService = masterService;
        }

        [HttpGet]
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult Login(Login login)
        {
            _authProvider.Authenticate(login);

            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        [Route("register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if (string.Equals("Master", user.Role, StringComparison.CurrentCultureIgnoreCase))
            {
                var userToAdd = Mapper.Map<UserViewModel, User>(user);

                _userService.Create(userToAdd);

                var masterToAdd = Mapper.Map<UserViewModel, Master>(user);

                using (var binaryReader = new BinaryReader(Request.Files[0].InputStream))
                {
                    masterToAdd.Photo = binaryReader.ReadBytes(Request.Files[0].ContentLength);
                }

                _masterService.Add(masterToAdd, user.Login);
            }

            if (string.Equals("Client", user.Role, StringComparison.CurrentCultureIgnoreCase))
            {
                var userToAdd = Mapper.Map<UserViewModel, User>(user);

                _userService.Create(userToAdd);

                var clientToAdd = Mapper.Map<UserViewModel, Client>(user);

                _clientService.Add(clientToAdd, user.Login);
            }

            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        [Route("logout")]
        public ActionResult Logout()
        {
            _authProvider.Deauthenticate();

            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        [Route("profile")]
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}