using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineStore.Web.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "First Name is Required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "First Name can't be less than 3 letters or more than 50")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address , ex : john@hotmail.com")]
        [Remote("IsValidEmail", "Account", ErrorMessage = "This email is allready in use")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Password must be Minimum 8 characters at least 1 Uppercase Alphabet, 1 Lowercase Alphabet and 1 Number")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

    }
}