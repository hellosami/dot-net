using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Notes_Practice.CustomValidators
{
    public class CheckBoxRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            // for printing on output window (choose View > Output, or press Ctrl+Alt+O)
            System.Diagnostics.Debug.WriteLine(Convert.ToString(value));
            if (Convert.ToString(value) == "on") return true;
            return false;
        }
    }
}