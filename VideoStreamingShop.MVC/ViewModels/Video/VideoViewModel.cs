using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.MVC.ViewModels.Video
{
    public class VideoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string AgeRate { get; set; }
        public string ImageUri { get; set; }
    }
}
