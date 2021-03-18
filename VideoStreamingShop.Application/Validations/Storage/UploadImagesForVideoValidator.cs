using FluentValidation;
using VideoStreamingShop.Application.Commands.Storage;

namespace VideoStreamingShop.Application.Validations.Storage
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
