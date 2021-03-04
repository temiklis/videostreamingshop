using FluentValidation;
using VideoStreamingShop.Core.Infrastructure.Commands.Storage;

namespace VideoStreamingShop.Core.Infrastructure.Validations.Storage
{
    public class UploadVideoRequestMessageValidator : AbstractValidator<UploadVideoRequestMessage>
    {
        public UploadVideoRequestMessageValidator()
        {
            RuleFor(r => r.VideoId).NotEmpty();
            RuleFor(r => r.VideoName).NotEmpty();
        }
    }
}
