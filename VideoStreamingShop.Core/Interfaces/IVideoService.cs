using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IVideoService
    {
        Task<IEnumerable<VideoDTO>> GetAllVideo(int page, int count);
        Task<VideoDTO> GetVideoById(int id);
        Task<string> UploadVideoFile(Stream stream);

        Task<VideoDTO> GetNotFullyCreatedVideos();
    }
}
