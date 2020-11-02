using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
    public class CreateVideoIteractor : IRequestHandler<CreateVideoRequestMessage, CreateVideoResponseMessage>
    {
        //need to add automapper here
        private readonly IRepository _repository;
        private readonly IVideoFileStorage _videoFileStorage;
        private readonly IValidator<CreateVideoRequestMessage> _validator;
        public CreateVideoIteractor(IRepository repository, IValidator<CreateVideoRequestMessage> validator, IVideoFileStorage videoFileStorage)
        {
            _validator = validator;
            _repository = repository;
            _videoFileStorage = videoFileStorage;
        }
        public async Task<CreateVideoResponseMessage> Handle(CreateVideoRequestMessage request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return new CreateVideoResponseMessage(validationResult);


            VideoFile videoFile = new VideoFile();
            if(request.FileData != null && request.FileData.Length == 0)
            {
                var uri = await _videoFileStorage.UploadVideo(request.FileData);
                videoFile = new VideoFile()
                {
                    Uri = uri,
                    Version = "1",
                    Name = string.Empty
                };
            }

            var video = new Video()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                AgeRate = request.AgeRate,
                LinkedFile = videoFile,
                Images = new List<VideoImage>() { 

                }
            };

            var vd = await _repository.AddAsync<Video>(video);
            return new CreateVideoResponseMessage(validationResult, vd.Id);
        }
    }

    public class CreateVideoRequestMessageValidator : AbstractValidator<CreateVideoRequestMessage>
    {
        public CreateVideoRequestMessageValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Description).NotEmpty();
            RuleFor(r => r.Price).NotEmpty();
            RuleFor(r => r.AgeRate).IsInEnum();
        }
    }


    public class CreateVideoRequestMessage: IRequest<CreateVideoResponseMessage>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public AgeRating AgeRate { get; set; }
        public byte[] FileData { get; set; }
    }

    public class CreateVideoResponseMessage
    {
        public int? VideoId { get; private set; }
        public ValidationResult ValidationResult { get; private set; }
        public CreateVideoResponseMessage(ValidationResult validationResult, int? videoId = null)
        {
            this.ValidationResult = validationResult;
            this.VideoId = videoId;
        }
    }
}
