using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.MVC.ViewModels.Video
{
    public class CreateVideoViewModel
    {
        public int VideoId { get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [MinLength(100)]
        [MaxLength(1000)]
        [DataType(DataType.MultilineText)]
        [DisplayName("Description")]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [DisplayName("Price")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Age Rating")]
        public AgeRating AgeRating { get; set; }
        [DisplayName("File")]
        public List<IFormFile> File { get; set; }
    }
}
