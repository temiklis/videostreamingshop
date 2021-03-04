using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Specifications;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
    /// <summary>
    /// Returns videos which have base information, but haven't images and video file.
    /// </summary>
    public class GetNotFullyCreatedVideosIteractor : IRequestHandler<GetNotFullyCreatedVideosRequest, GetNotFullyCreatedVideosResponse>
    {
        private readonly IRepository _repository;
        public GetNotFullyCreatedVideosIteractor(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetNotFullyCreatedVideosResponse> Handle(GetNotFullyCreatedVideosRequest request, CancellationToken cancellationToken)
        {
            var notFullyCreatedVideoSpecification = new VideoNotFullyCreatedSpecification(request.Skip, request.Count);

            var videos = await _repository.GetListAsync<Video>(notFullyCreatedVideoSpecification);

            return new GetNotFullyCreatedVideosResponse() { Videos = videos };
        }
    }
}
