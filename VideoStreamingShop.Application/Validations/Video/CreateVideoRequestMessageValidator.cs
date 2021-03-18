using FluentValidation;
using VideoStreamingShop.Application.Commands.Video;

namespace VideoStreamingShop.Application.Validations.Video
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
