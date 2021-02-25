using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Usecases.Videocases;

namespace VideoStreamingShop.API.MapperProfiles
{
    public class VideoMappingProfile: Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<VideoDTO, CreateVideoRequestMessage>();
            CreateMap<Video, VideoDTO>();
        }
    }
}
