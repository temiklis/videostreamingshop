using FluentValidation.Results;

namespace VideoStreamingShop.Application.Commands.Video
{
    public class CreateVideoResponseMessage
    {
        public int? VideoId { get; private set; }
        public ValidationResult ValidationResult { get; private set; }
        public CreateVideoResponseMessage(ValidationResult validationResult, int? videoId = null)
        {
            this.ValidationResult = validationResult;
            this.VideoId = videoId;
        }
    }
}
