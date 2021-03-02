using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Infrastructure;
using VideoStreamingShop.Web.Infrastructure.ValidationAttributes;
using VideoStreamingShop.Web.Models;

namespace VideoStreamingShop.Web.ViewModels.Video
{
    public class CreateVideoViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MinLength(300)]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        [Required]
        public string AgeRate { get; set; }
    }
}
