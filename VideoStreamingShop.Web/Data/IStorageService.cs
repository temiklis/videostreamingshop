using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Models.DTOs;

namespace VideoStreamingShop.Web.Data
{
    public interface IStorageService
    {
        Task<IEnumerable<string>> UploadImagesForVideo(UploadImagesForVideoDTO uploadImagesForVideoDTO);
    }
}
