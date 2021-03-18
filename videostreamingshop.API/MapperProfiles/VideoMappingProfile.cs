using AutoMapper;
using VideoStreamingShop.Application.Commands.Video;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;

namespace VideoStreamingShop.API.MapperProfiles
{
    public class VideoMappingProfile: Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<CreateVideoDTO, CreateVideoRequestMessage>();
            CreateMap<Video, VideoDTO>();
        }
    }
}
