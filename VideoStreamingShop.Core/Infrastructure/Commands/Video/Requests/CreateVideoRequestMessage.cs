﻿using MediatR;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
    public class CreateVideoRequestMessage: IRequest<CreateVideoResponseMessage>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public AgeRating AgeRate { get; set; }
    }
}
