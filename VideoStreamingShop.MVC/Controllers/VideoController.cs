using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VideoStreamingShop.Core.Entities;
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
        private readonly CreateVideoIteractor _createVideoIterator;

#warning Need to use mediatR for all methods, bacause we have large constructor and unnessary dependecies.(or use some patterns) 
        public VideoController(IVideoService videoService, IMediator mediator, IMapper mapper, UploadVideoIteractor iteractor, CreateVideoIteractor createVideoIterator )
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

        [Route("Video/{id}")]
        public async Task<IActionResult> Detail (int id)
        {
            var video = await _videoService.GetVideoById(id);
            var viewModel = _mapper.Map<VideoViewModel>(video);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVideoViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var request = new CreateVideoRequestMessage()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                AgeRate = viewModel.AgeRating,
                Price = viewModel.Price,
            };

            if(viewModel.File != null)
            {
                using(var ms = new MemoryStream())
                {
                    viewModel.File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    request.FileData = fileBytes;
                }
            }    

            var response = await _createVideoIterator.Handle(request, CancellationToken.None);

            if (response.VideoId != null)
                return RedirectToAction("Get", response.VideoId);

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
