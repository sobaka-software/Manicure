using System;
using System.Web;
using System.Web.Security;
using Manicure.BusinessLogic.Services.Abstract;

namespace Manicure.BusinessLogic.Authentication
{
    public class AuthProvider
    {
        private readonly IUserService _userService;
        public AuthProvider(IUserService userService)
        {
            _userService = userService;
        }

        public bool Authenticate(Login login)
        {
            var user = _userService.GetBy(login.UserLogin, login.Password);

            if (user != null)
            {
                var timeout = login.RememberMe ? 525600 : 60;
                var authTicket = new FormsAuthenticationTicket(login.UserLogin, login.RememberMe, timeout);
                var encryptedAuthTicket = FormsAuthentication.Encrypt(authTicket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedAuthTicket)
                {
                    Expires = DateTime.Now.AddMinutes(timeout),
                    HttpOnly = true
                };
                HttpContext.Current.Response.Cookies.Add(cookie);

                return true;
            }
            return false;
        }

        public void Deauthenticate()
        {
            FormsAuthentication.SignOut();
        }
    }
}