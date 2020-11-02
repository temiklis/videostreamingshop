using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VideoStreamingShop.MVC.ViewModels.Video
{
    public class UploadFileViewModel
    {
        public string Name { set; get; }
        public string Description { get; set; }
        public IFormFile File { get; set; }
    }
}