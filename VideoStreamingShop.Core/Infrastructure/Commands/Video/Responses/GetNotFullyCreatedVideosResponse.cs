using System.Collections.Generic;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
    public class GetNotFullyCreatedVideosResponse
    {
        public IEnumerable<Video> Videos { get; internal set; }
    }
}
