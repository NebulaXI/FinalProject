using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiProject.Infrastructure.Validations
{
    public class BankCardAttribute : ValidationAttribute,IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("card-val", "true");
            context.Attributes.Add("card-val-number",
            "Credit card number must be in format:0000-0000-0000-0000");
        }
        protected override ValidationResult IsValid
            (object value, ValidationContext validationContext)
        { if (value!= @"(\d{4}[- ]?){4}|\d{4}[- ]?\d{6}[- ]?\d{5}")
            {
                return new ValidationResult("Credit card number must be in format:0000-0000-0000-0000");
            }
            return ValidationResult.Success;
        }
    }
}
