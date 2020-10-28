using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.MVC.ViewModels.Video
{
    public class CreateVideoViewModel
    {
        [Required]
        [MinLength(20)]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [MinLength(100)]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [DisplayName("Price")]
        public int Price { get; set; }
        [Required]
        [DisplayName("Age Rating")]
        public AgeRating AgeRating { get; set; }
        [DisplayName("File")]
        public IFormFile File { get; set; }
    }
}
