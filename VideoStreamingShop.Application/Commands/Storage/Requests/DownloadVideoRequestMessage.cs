using MediatR;

namespace VideoStreamingShop.Application.Commands.Storage
{
    public class DownloadVideoRequestMessage : IRequest<DownloadVideoResponseMessage>
    {
        public int VideoId { get; set; }
    }
}
