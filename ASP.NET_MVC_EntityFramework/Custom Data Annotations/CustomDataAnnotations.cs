using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ASP.NET_MVC_EntityFramework.Custom_Data_Annotations
{
   public class PublishDateAttribute : ValidationAttribute
    {
        public PublishDateAttribute():base("{0} Should be less than Current Date")
        {

        }
        public override bool IsValid(object value)
        {
            DateTime proValue =Convert.ToDateTime(value);

            if (proValue < DateTime.Now)
                return true;
            else
                return false;
        }
    }

    public class UpperCaseAttribute : ValidationAttribute
    {
        //UpperCase
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string suppliedValue = (string)value;
                var hasUpperChar = new Regex(@"[A-Z]+");
                var match = hasUpperChar.IsMatch(suppliedValue);
                if (match == false)
                {
                    return new ValidationResult("Input Should Have Uppercase ");
                }
            }
            return ValidationResult.Success;
        }
    }
}