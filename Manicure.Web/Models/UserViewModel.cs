using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Manicure.Web.Models
{
    public class UserViewModel
    {
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public byte[] Photo { get; set; }

        public string Role { get; set; }
    }
}