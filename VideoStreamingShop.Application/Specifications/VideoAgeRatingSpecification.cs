using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Application.Specifications
{
    public class VideoAgeRatingSpecification : Specification<Video>
    {
        public VideoAgeRatingSpecification()
        {
            Query.Where(v => true);
        }
    }
}
