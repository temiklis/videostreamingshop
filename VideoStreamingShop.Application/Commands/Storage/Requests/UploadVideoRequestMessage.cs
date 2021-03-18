using MediatR;

namespace VideoStreamingShop.Application.Commands.Storage
{
    public class UploadVideoRequestMessage : IRequest<UploadVideoResponseMessage>
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public byte[] Data { get; set; }
    }
}
