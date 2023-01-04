using SkiProject.Infrastructure.Data.Models.Account;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkilProject.Infrastructure.Validations
{
    /// <summary>
    /// Custom attribute for the application user age
    /// </summary>
    public class UserAgeAttribute:ValidationAttribute,IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-birthdate",
            "User must be at least 16 years old.");
        }

        protected override ValidationResult IsValid
            (object value, ValidationContext validationContext)
        {
            DateTime birthdateInput = DateTime.Parse(value.ToString());
            var today = DateTime.Today;
            var userMade16 = birthdateInput.AddYears(16);

            if (userMade16.Date > today.Date)
            {
                return new ValidationResult("User must be at least 16 years old.");
            }
            return ValidationResult.Success;
        }
    }
    //public UserAgeAttribute(int years)
    //    {
    //        Years = years;
    //    }
    //    public int Years { get;}

    //    public string GetErrorMessage()
    //        =>$"Each user MUST be at least {Years} years old.";

    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        var user = (ApplicationUser)validationContext.ObjectInstance;
    //        var today = DateTime.Today;
    //        var userMade18 = user.Birthday.AddYears(18);
    //        if (userMade18.Date>today.Date)
    //        {
    //            return new ValidationResult(GetErrorMessage());
    //        }

    //        return ValidationResult.Success;
    //    }
    //}
}
