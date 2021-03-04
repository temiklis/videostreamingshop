using FluentValidation.Results;

namespace VideoStreamingShop.Core.Infrastructure.Commands.Storage
{
    public class UploadVideoResponseMessage
    {
        public ValidationResult validationResult { get; }
        public int? VideoId { get; private set; }
        public string Uri { get; private set; }

        public UploadVideoResponseMessage(ValidationResult validationResult, int? videoId = null, string uri = null)
        {
            this.validationResult = validationResult;
            VideoId = videoId;
            Uri = uri;
        }

    }
}
