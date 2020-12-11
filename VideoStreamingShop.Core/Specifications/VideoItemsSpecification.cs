using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Core.Specifications
{
    public class VideoItemsSpecification : Specification<Video>
    {
        public VideoItemsSpecification(int page, int count)
        {
            Query.Where(v => v.LinkedFile != null && v.Images.Count > 0)
                .Skip(count * page)
                .Take(count);
        }
    }
}
