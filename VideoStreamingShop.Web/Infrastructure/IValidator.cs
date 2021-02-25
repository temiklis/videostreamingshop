using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.Web.Infrastructure
{
    public interface IValidator 
    {
        bool Validate(object obj);
    }
}
