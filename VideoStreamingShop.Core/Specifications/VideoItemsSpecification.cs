using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Specifications
{
    internal class VideoItemsSpecification : Specification<Video>
    {
        public VideoItemsSpecification(int page, int count)
        {
            Query.Skip(count * page)
                 .Take(count);
        }
    }
}
