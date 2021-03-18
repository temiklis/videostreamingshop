using MediatR;
using System.Collections.Generic;

namespace VideoStreamingShop.Application.Commands.Storage
{
    public class UploadImagesForVideoRequestMessage : IRequest<UploadImagesForVideoResponseMessage>
    {
        public int VideoId { get; set; }
        public List<byte[]> FilesData { get; set; }
    }

}
