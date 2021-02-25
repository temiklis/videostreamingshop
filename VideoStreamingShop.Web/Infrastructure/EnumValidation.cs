using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.Web.Infrastructure
{
    public class EnumValidation<T> : IValidator 
        where T: Enum
    {
        public bool Validate(object value)
        {
            string model = (string)value;

            if (Enum.TryParse(typeof(T), model, out var rating))
            {
                return true;
            }

            return false;
        }
    }
}
