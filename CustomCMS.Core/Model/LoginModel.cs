using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace CustomCMS.Core.Model
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter Password")]
        //[MembershipPassword(
        //    MinRequiredNonAlphanumericCharacters = 1,
        //    MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        //    ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).",
        //    MinRequiredPasswordLength = 6
        //)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; }

        public Boolean IsRemember { get; set; }
    }
}
