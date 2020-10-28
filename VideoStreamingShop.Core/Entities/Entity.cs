using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Entities
{
    public abstract class Entity 
    {
        //make private set after testing, user must don't have access to this property
        public int Id { get; set; }
        protected DateTime CreatedDate { get; set; }
    }
}
