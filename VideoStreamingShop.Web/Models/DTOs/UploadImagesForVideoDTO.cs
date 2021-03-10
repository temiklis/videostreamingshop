using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Models.Shared;

namespace VideoStreamingShop.Web.Models.DTOs
{
    public class UploadImagesForVideoDTO
    {
        public int Id { get; set; }
        public IEnumerable<FileData> Files { get; set; }
    }
}
