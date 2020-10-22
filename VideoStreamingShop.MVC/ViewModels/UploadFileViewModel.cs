using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.MVC.ViewModels
{
    public class UploadFileViewModel
    {
        public string ImageCaption { set; get; }
        public string ImageDescription { get; set; }
        public IFormFile Image { get; set; }
    }
}
