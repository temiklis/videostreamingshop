using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.Application.Specifications
{
    internal class VideoNotFullyCreatedSpecification : Specification<Video>
    {
        public VideoNotFullyCreatedSpecification(int skip = 0, int count = 20)
        {
            Query.Where(v => v.LinkedFile == null || v.Images.Count == 0);
        }
    }
}
