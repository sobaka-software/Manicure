using System;
using System.Web;
using System.Web.Security;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Auth;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Authentication
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IUserService _userService;

        public AuthProvider(IUserService userService)
        {
            _userService = userService;
        }

        public User Authenticate(Login login)
        {
            var user = _userService.GetBy(login.UserLogin, login.Password);

            if (user != null)
            {
                var timeout = login.RememberMe ? 525600 : 60;
                var authTicket = new FormsAuthenticationTicket(
                    1,
                    login.UserLogin,
                    DateTime.Now,
                    DateTime.Now.AddHours(1),
                    login.RememberMe,
                    string.Join("|", user.Role));
                var encryptedAuthTicket = FormsAuthentication.Encrypt(authTicket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedAuthTicket)
                {
                    Expires = DateTime.Now.AddMinutes(timeout),
                    HttpOnly = true
                };
                HttpContext.Current.Response.Cookies.Add(cookie);

                return user;
            }

            return null;
        }

        public void Deauthenticate()
        {
            FormsAuthentication.SignOut();
        }
    }
}