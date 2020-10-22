using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Specifications;

namespace VideoStreamingShop.Infrasturcture.Services
{
    internal class VideoService : IVideoService
    {
        private readonly IRepository _repository;
        public VideoService(IRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<VideoDTO>> GetAllVideo(int page, int count)
        {
            var specification = new VideoItemsSpecification(page, count);
            var videos = await _repository.GetListAsync(specification);

            var videoDtos = videos.ConvertAll<VideoDTO>(video =>
            {
                return new VideoDTO()
                {
                    Name = video.Name,
                    Price = video.Price,
                    Description = video.Description,
                    AgeRate = video.AgeRate
                };
            });
            return videoDtos;
        }
    }
}
