using System;
using System.Collections.Generic;
using System.Text;

namespace VideoStreamingShop.Core.DTOs
{
    public class VideoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string AgeRate { get; set; }
        public string ImageUri { get; set; }
    }
}
