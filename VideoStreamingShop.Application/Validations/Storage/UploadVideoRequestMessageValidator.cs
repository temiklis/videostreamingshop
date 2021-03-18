using FluentValidation;
using VideoStreamingShop.Application.Commands.Storage;

namespace VideoStreamingShop.Application.Validations.Storage
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
