using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VideoStreamingShop.Application.Commands.Storage;
using VideoStreamingShop.Application.Commands.Video;
using VideoStreamingShop.Core.DTOs;
using VideoStreamingShop.Core.Interfaces;

//need to add specific dto for all actions;
namespace VideoStreamingShop.API.Controllers
{
    [ApiController]
    [Route("api/video")]
    public class VideoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IVideoService _videoService;

        public VideoController(IMediator mediator, IVideoService videoService, IMapper mapper)
        {
            _mediator = mediator;
            _videoService = videoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<VideoDTO>> Get(int skip = 0, int take = 20) => 
            await _videoService.GetAllVideo(skip, take);

        [HttpGet("{id}")]
        public async Task<VideoDTO> Get(int id) => 
            await _videoService.GetVideoById(id);

        //TODO: need to secure route
        [HttpPost("create")]
        public async Task<ActionResult<int>> Create([FromBody]CreateVideoDTO video)
        {
            var request = _mapper.Map<CreateVideoRequestMessage>(video);
            var response = await _mediator.Send(request);

            if (response.VideoId == null)
                return NoContent();

            return Ok(response.VideoId);
        }

        //TODO secure route  
        [HttpGet("GetNotFullyCreated")]
        public async Task<ActionResult<VideoDTO>> GetNotFullyCreatedVideos(int page = 0, int count = 20)
        {
            var request = new GetNotFullyCreatedVideosRequest()
            {
                Count = count,
                Skip = page * count
            };

            var response = await _mediator.Send(request);

            //TODO MAP videos in use cases
            return Ok(response.Videos);
        } 

        [HttpPost("addImages")]
        public async Task<ActionResult> UploadImagesForVideo(IList<IFormFile> files, [FromQuery] int videoId)
        {
            var request = new UploadImagesForVideoRequestMessage()
            {
                FilesData = new List<byte[]>(),
                VideoId = videoId
            };

            foreach (var file in files)
            {
                using(var stream = new MemoryStream())
                {
                    file.CopyTo(stream);
                    request.FilesData.Add(stream.ToArray());
                }
            }

            var response = await _mediator.Send(request);

            return Ok(response.Paths);
        }

        [HttpPost("uploadVideoFile")]
        public async Task<IActionResult> UploadVideoFile([FromBody] IFormFile video, int videoId)
        {
            var request = new UploadVideoRequestMessage()
            {
                VideoId = videoId,
                VideoName = string.Empty
            };

            using (var stream = new MemoryStream())
            {
                video.CopyTo(stream);
                request.Data = stream.ToArray();
            }

            var response = await _mediator.Send(request);

            return Ok(response.Uri);
        }
    }
}
