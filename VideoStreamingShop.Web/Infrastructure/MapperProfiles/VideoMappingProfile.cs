using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Web.Models.DTOs;
using VideoStreamingShop.Web.ViewModels.Video;

namespace VideoStreamingShop.Web.Infrastructure.MapperProfiles
{
    public class VideoMappingProfile : Profile
    {
        public VideoMappingProfile()
        {
            CreateMap<CreateVideoViewModel, CreateVideoDTO>();
        }
    }
}
