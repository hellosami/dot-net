using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Notes_Practice.CustomValidators;

namespace Notes_Practice.Models
{
    public class Profile
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Department { get; set; }

        [CheckBoxRequired]
        public string IsAgreed { get; set; }
    }
}