using FluentValidation;
using VideoStreamingShop.Core.Infrastructure.Commands.Storage;

namespace VideoStreamingShop.Core.Infrastructure.Validations.Storage
{
    public class UploadImagesForVideoValidator : AbstractValidator<UploadImagesForVideoRequestMessage>
    {
        public UploadImagesForVideoValidator()
        {
            RuleFor(r => r.VideoId).NotEmpty();
            RuleFor(r => r.FilesData.Count).LessThan(4);
        }
    }

}
