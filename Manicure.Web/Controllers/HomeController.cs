using System.Web.Mvc;
using Manicure.BusinessLogic.Authentication;
using Manicure.BusinessLogic.Services.Concrete;
using Manicure.Common.Domain;
using Manicure.DataAccess.Context;

namespace Manicure.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthProvider _authProvider;

        public HomeController()
        {
            _authProvider = new AuthProvider(new UserService());
        }

        [Route("")]
        public ActionResult Main()
        {
            var a = new ManicureContext();
            a.Users.Add(new User());
            a.SaveChanges();


            //var sd = _authProvider.Authenticate(new Login());
            return View();
        }
    }
}