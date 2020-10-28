﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.MVC.ViewModels;
using VideoStreamingShop.MVC.ViewModels.Video;

namespace VideoStreamingShop.MVC.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VideoDTO, VideoViewModel>();
        }
    }
}
