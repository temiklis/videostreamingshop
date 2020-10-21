using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Entities
{
    public abstract class Entity 
    {
        protected int Id { get; set; }
        protected DateTime CreatedDate { get; set; }
    }
}
