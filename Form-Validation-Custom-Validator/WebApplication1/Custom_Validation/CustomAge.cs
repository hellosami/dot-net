using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Custom_Validation
{
    public class CustomAge : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            // Save today's date.
            var today = DateTime.Today;

            // Calculate the age.
            var age = today.Year - Convert.ToDateTime(value).Year;

            if (age > 18) return true;
            return false;
        }
    }
}