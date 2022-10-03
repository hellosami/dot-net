using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Custom_Validation;
namespace WebApplication1.Models
{
    public class Student
    {
        [Required, MinLength(3)]
        [RegularExpression("^[a-zA-Z. ]*$", ErrorMessage = "Only Alphabets, Space and Dot Allowed!")]
        
        public string Name { get; set; }

        [Required]
        [RegularExpression("^\\d{2}-\\d{5}-\\d{1}$", ErrorMessage = "Please Follow The Format: XX-XXXXX-X")]
        public string ID { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(01[6789])(\\d{8})$", ErrorMessage = "Please Follow The Format: 01XXXXXXXXX")]

        public string Phone { get; set; }

        [Required]
        [CustomAge(ErrorMessage = "Hire Date must be less than or equal to Today's Date")]
        public string Date { get; set; }


        [Required, MinLength(8)]
        [RegularExpression("(?=[A-Za-z0-9@#$%^&+!=]+$)^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[@#$%^&+!=])(?=.{8,}).*$", ErrorMessage = "Invalid Pass")]
        public string Password { get; set; }

        [Required, MinLength(8)]
        [Compare("Password")]
        public string CPassword { get; set; }


    }
}