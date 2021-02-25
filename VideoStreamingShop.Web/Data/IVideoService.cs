using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Models.Video;
using VideoStreamingShop.Web.ViewModels;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Data
{
    public interface IVideoService
    {
        Task<IEnumerable<VideoCardViewModel>> Get(int page, int take);
        Task<VideoPageViewModel> GetById(int id);

        Task<NotFullyCreatedVideoViewModel> GetNotFullyCreatedVideos(int page, int count);
        Task<bool> CreateVideoWithBaseInformation(CreateVideoViewModel createVideoViewModel);
    }
}
