using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ASP.NET_MVC_EntityFramework.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [Display(Name = " Username")]
        public string UserName { get; set; }

        [Required, EmailAddress]
        [Display(Name = " E-mail Address")]
        public string Email { get; set; }

        [Required, StringLength(60, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display(Name = " Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirm password do not match.")]
        [Display(Name = " Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPasswor { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Invalid username")]
        [Display(Name = " Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Invalid password"), DataType(DataType.Password)]
        [Display(Name = " Password")]
        public string Password { get; set; }
    }
}