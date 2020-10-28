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

namespace VideoStreamingShop.Core.Usecases.Storage
{
    public class UploadVideoIteractor : IRequestHandler<UploadVideoRequestMessage, UploadVideoResponseMessage>
    {
        private readonly IRepository _repository;
        private readonly IValidator<UploadVideoRequestMessage> _validator;
        private readonly IVideoFileStorage _videoFileStorage;
        public UploadVideoIteractor(IRepository repository, IValidator<UploadVideoRequestMessage> validator, IVideoFileStorage videoFileStorage)
        {
            _repository = repository;
            _validator = validator;
            _videoFileStorage = videoFileStorage;
        }
        public  async Task<UploadVideoResponseMessage> Handle(UploadVideoRequestMessage request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new UploadVideoResponseMessage(validationResult);
            }

            var video = await _repository.GetByIdAsync<Video>(request.VideoId);
            var uri = await _videoFileStorage.UploadVideo(request.Data);

            video.LinkedFile = new VideoFile()
            {
                Name = request.VideoName,
                Uri = uri,
                Version = string.Empty
            };
            await _repository.UpdateAsync(video);

            return new UploadVideoResponseMessage(validationResult, request.VideoId, uri);
        }
    }

    public class UploadVideoRequestMessageValidator : AbstractValidator<UploadVideoRequestMessage>
    { 
        public UploadVideoRequestMessageValidator()
        {
            RuleFor(r => r.VideoId).NotEmpty();
            RuleFor(r => r.VideoName).NotEmpty();
        }
    }

    public class UploadVideoRequestMessage : IRequest<UploadVideoResponseMessage>
    {
        public int VideoId { get; set; }
        public string VideoName { get; set; }
        public byte[] Data { get; set; }
    }

    public class UploadVideoResponseMessage 
    {
        public ValidationResult validationResult { get; }

        public UploadVideoResponseMessage(ValidationResult validationResult, int? videoId = null, string uri = null)
        {
            this.validationResult = validationResult;
            this.VideoId = videoId;
            this.Uri = uri;
        }
        public int? VideoId { get; private set; }
        public string Uri { get; private set; }
    }
}
