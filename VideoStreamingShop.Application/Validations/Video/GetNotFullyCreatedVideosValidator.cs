using FluentValidation;
using VideoStreamingShop.Application.Commands.Video;

namespace VideoStreamingShop.Application.Validations.Video
{
    public class GetNotFullyCreatedVideosValidator : AbstractValidator<GetNotFullyCreatedVideosRequest>
    {
        public GetNotFullyCreatedVideosValidator()
        {

        }
    }
}
