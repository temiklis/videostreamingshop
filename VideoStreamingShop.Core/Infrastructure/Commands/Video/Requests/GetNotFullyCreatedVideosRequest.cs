﻿using MediatR;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
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
}
