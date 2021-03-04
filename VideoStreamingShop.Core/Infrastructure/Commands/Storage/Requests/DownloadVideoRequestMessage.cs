using MediatR;

namespace VideoStreamingShop.Core.Infrastructure.Commands.Storage
{
    public class DownloadVideoRequestMessage : IRequest<DownloadVideoResponseMessage>
    {
        public int VideoId { get; set; }
    }
}
