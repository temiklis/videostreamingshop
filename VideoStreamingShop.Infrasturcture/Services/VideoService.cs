using Ardalis.Specification;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        private readonly IMapper _mapper;
        public VideoService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<VideoDTO>> GetAllVideo(int page, int count)
        {
            var specification = new VideoItemsSpecification(page, count);
            var videos = await _repository.GetListAsync(specification);

            var dtos = _mapper.Map<IEnumerable<VideoDTO>>(videos);

            return dtos;
        }

        public Task<VideoDTO> GetNotFullyCreatedVideos()
        {
            throw new NotImplementedException();
        }

        public async Task<VideoDTO> GetVideoById(int id)
        {
            var video = await _repository.GetByIdAsync<Video>(id);
            if (video == null)
                return null;

            var videoDTo = _mapper.Map<VideoDTO>(video);

            return videoDTo;
        }

        public Task<string> UploadVideoFile(Stream stream)
        {
            throw new NotImplementedException();
        }
    }
}
