using FluentValidation;
using VideoStreamingShop.Core.Infrastructure.Commands.Storage;

namespace VideoStreamingShop.Core.Infrastructure.Validations.Storage
{
    public class DownloadVideoResponseMessageValidator : AbstractValidator<DownloadVideoRequestMessage>
    {
        public DownloadVideoResponseMessageValidator()
        {
            RuleFor(r => r.VideoId).NotEmpty();
        }
    }
}
