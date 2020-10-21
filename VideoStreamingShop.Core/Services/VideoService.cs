using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Specifications;

namespace VideoStreamingShop.Core.Services
{
    internal class VideoService : IVideoService
    {
        private readonly IRepository _repository;
        public VideoService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Video>> GetAllVideo(int page, int count)
        {
            var specification = new VideoItemsSpecification(page, count);
            var videos = await _repository.GetListAsync(specification);
            return videos;
        }
    }
}
