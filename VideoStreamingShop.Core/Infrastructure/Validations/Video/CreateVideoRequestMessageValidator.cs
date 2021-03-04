using FluentValidation;
using VideoStreamingShop.Core.Usecases.Videocases;

namespace VideoStreamingShop.Core.Infrastructure.Validations.Video
{
    public class CreateVideoRequestMessageValidator : AbstractValidator<CreateVideoRequestMessage>
    {
        public CreateVideoRequestMessageValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Description).NotEmpty();
            RuleFor(r => r.Price).NotEmpty();
            RuleFor(r => r.AgeRate).IsInEnum();
        }
    }
}
