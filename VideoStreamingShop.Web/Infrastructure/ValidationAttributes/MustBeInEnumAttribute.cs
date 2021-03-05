using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.Web.Infrastructure.ValidationAttributes
{
    public class MustBeInEnumAttribute : ValidationAttribute
    {
        private Type _enumType;
        public MustBeInEnumAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!_enumType.IsEnum)
            {
                throw new NotSupportedException($"{this.GetType().Name} must be contain enums type only");
            }

            string model = (string)value;

            if (Enum.TryParse(_enumType, model, out var result))
            {
                return ValidationResult.Success;
            }

            return new ValidationResult($"{validationContext.DisplayName} must be in enum");
        }
    }
}
