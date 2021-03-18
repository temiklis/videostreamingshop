using FluentValidation;
using VideoStreamingShop.Application.Commands.Storage;

namespace VideoStreamingShop.Application.Validations.Storage
{
    public class DownloadVideoResponseMessageValidator : AbstractValidator<DownloadVideoRequestMessage>
    {
        public DownloadVideoResponseMessageValidator()
        {
            RuleFor(r => r.VideoId).NotEmpty();
        }
    }
}
