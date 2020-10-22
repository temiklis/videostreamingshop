using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.Entities
{
    public abstract class Entity 
    {
        public int Id { get; private set; }
        protected DateTime CreatedDate { get; set; }
    }
}
