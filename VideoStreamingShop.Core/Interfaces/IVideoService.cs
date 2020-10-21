using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Interfaces
{
    public interface IVideoService
    {
        Task<List<Video>> GetAllVideo(int page, int count);
    }
}
