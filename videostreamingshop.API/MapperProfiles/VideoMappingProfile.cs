using AutoMapper;
using VideoStreamingShop.Application.Commands.Video;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;
using System.Linq;

namespace VideoStreamingShop.API.MapperProfiles
{
    public class VideoMappingProfile: Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<CreateVideoDTO, CreateVideoRequestMessage>();
            CreateMap<Video, VideoDTO>()
                .ForMember(
                dest => dest.ImageUri, 
                opt => opt.MapFrom((video,source) => video.Images.FirstOrDefault()?.Uri)) ;
        }
    }
}
