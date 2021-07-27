using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Helpers
{
    public class NewCustomValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string booName = value.ToString();
                if (booName.Contains("mvc"))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Book name does not contains mvc string value");
        }
    }
}
