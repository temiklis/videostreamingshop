using System.Collections.Generic;

namespace VideoStreamingShop.Application.Commands.Video
{
    public class GetNotFullyCreatedVideosResponse
    {
        public IEnumerable<Core.Entities.Video> Videos { get; internal set; }
    }
}
