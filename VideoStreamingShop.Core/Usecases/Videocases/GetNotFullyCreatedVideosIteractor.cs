using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Specifications;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
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

    public class GetNotFullyCreatedVideosValidator : AbstractValidator<GetNotFullyCreatedVideosRequest>
    {
        public GetNotFullyCreatedVideosValidator()
        {

        }
    }

    public class GetNotFullyCreatedVideosRequest : IRequest<GetNotFullyCreatedVideosResponse>
    {
        public int Count { get; set; }
        public int Skip { get; set; }

        public GetNotFullyCreatedVideosRequest(int count = 20, int skip = 0)
        {
            Count = count;
            Skip = skip;
        }
    }

    public class GetNotFullyCreatedVideosResponse
    {
        public IEnumerable<Video> Videos { get; internal set; }
    }
}
