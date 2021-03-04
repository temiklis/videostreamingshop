using FluentValidation.Results;

namespace VideoStreamingShop.Core.Infrastructure.Commands.Storage
{
    public class DownloadVideoResponseMessage
    {
        public ValidationResult ValidationResult { get; private set; }
        public DownloadVideoResponseMessage(ValidationResult validationResult, int? videoId = null, byte[] data = default)
        {
            ValidationResult = validationResult;
            VideoId = videoId;
            Data = data;
        }
        public int? VideoId { get; private set; }
        public byte[] Data { get; private set; }
    }
}
