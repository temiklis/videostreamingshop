using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.MVC.ViewModels;

namespace VideoStreamingShop.MVC.Controllers
{
    public class VideoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;
        public VideoController(IVideoService videoService, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _videoService = videoService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page = 0, int count = 20)
        {
            var videos = await _videoService.GetAllVideo(page, count);
            var paginatedViewModel = new PaginationViewModel<VideoViewModel>()
            {
                Page = page,
                Count = count,
                Data = _mapper.Map<List<VideoViewModel>>(videos)
            };

            return View(paginatedViewModel);
        }
    }
}
