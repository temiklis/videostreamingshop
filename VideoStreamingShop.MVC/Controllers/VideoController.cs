using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IVideoFileStorage _videoFileStorage;

        public VideoController(IVideoService videoService, IVideoFileStorage videoFileStorage, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _videoService = videoService;
            _mapper = mapper;
            _videoFileStorage = videoFileStorage;
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

        //this is test methods, delete that after testing
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View(new UploadFileViewModel());
        }


        public async Task<IActionResult> UploadFile(UploadFileViewModel model)
        {
            var img = model.Image;
            var imgCaption = model.ImageCaption;

            MemoryStream stream = new MemoryStream();
            await model.Image.CopyToAsync(stream);
            var result = await _videoFileStorage.UploadVideo(stream.ToArray());

            return RedirectToAction("Index");
        }
    }
}
