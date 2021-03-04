using FluentValidation;
using VideoStreamingShop.Core.Usecases.Videocases;

namespace VideoStreamingShop.Core.Infrastructure.Validations.Video
{
    public class GetNotFullyCreatedVideosValidator : AbstractValidator<GetNotFullyCreatedVideosRequest>
    {
        public GetNotFullyCreatedVideosValidator()
        {

        }
    }
}
