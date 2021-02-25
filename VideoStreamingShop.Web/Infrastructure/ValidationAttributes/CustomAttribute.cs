using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Models;

namespace VideoStreamingShop.Web.Infrastructure.ValidationAttributes
{
    public class CustomAttribute : ValidationAttribute
    {
        private readonly IValidator _validator;
        public CustomAttribute(IValidator validator)
        {
            this._validator = validator;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isSuccess = _validator.Validate(value);

            if (isSuccess)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("value should be in enum");
        }
    }
}
