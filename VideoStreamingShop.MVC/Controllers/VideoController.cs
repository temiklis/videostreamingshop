using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Usecases;
using VideoStreamingShop.Core.Usecases.Storage;
using VideoStreamingShop.Core.Usecases.Videocases;
using VideoStreamingShop.MVC.ViewModels;
using VideoStreamingShop.MVC.ViewModels.Video;

namespace VideoStreamingShop.MVC.Controllers
{
    public class VideoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IVideoService _videoService;
        private readonly IMapper _mapper;
        private readonly UploadVideoIteractor _uploadVideoIteractor;
        private readonly CreateVideoIterator _createVideoIterator;

        //Need to use mediatR;
        public VideoController(IVideoService videoService, IMediator mediator, IMapper mapper, UploadVideoIteractor iteractor, CreateVideoIterator createVideoIterator )
        {
            _mediator = mediator;
            _videoService = videoService;
            _mapper = mapper;
            _uploadVideoIteractor = iteractor;
            _createVideoIterator = createVideoIterator;
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVideoViewModel viewModel)
        {
            var request = new CreateVideoRequestMessage()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                AgeRate = viewModel.AgeRating,
                Price = viewModel.Price
            };

            var response = await _createVideoIterator.Handle(request, CancellationToken.None);

            if (response.VideoId != null)
                return Ok(response.VideoId);

            return BadRequest();
        }

        //this is test methods, delete that after testing
        [HttpGet]
        public IActionResult UploadFile()
        {
            return View(new UploadFileViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadFileViewModel model)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                model.File.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            var request = new UploadVideoRequestMessage() {
                VideoName = model.Name,
                Data = fileBytes,
                VideoId = 1
            };

            var response = await _uploadVideoIteractor.Handle(request, CancellationToken.None);

            return RedirectToAction("Index");
        }
    }
}
