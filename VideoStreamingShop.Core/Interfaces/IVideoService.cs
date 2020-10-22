using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IVideoService
    {
        Task<List<VideoDTO>> GetAllVideo(int page, int count);
    }
}
