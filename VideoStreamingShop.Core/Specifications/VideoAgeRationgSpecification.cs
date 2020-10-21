using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Specifications
{
    public class VideoAgeRationgSpecification : Specification<Video>
    {
        public VideoAgeRationgSpecification()
        {
            Query.Where(v => true);
        }
    }
}
