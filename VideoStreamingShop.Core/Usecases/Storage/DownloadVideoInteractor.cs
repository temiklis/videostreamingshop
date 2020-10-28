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
    public class DownloadVideoInteractor : IRequestHandler<DownloadVideoRequestMessage, DownloadVideoResponseMessage>
    {
        public readonly IRepository _repository;
        public readonly IVideoFileStorage _videoFileStorage;
        public readonly IValidator<DownloadVideoRequestMessage> _validator;
        public async Task<DownloadVideoResponseMessage> Handle(DownloadVideoRequestMessage request, CancellationToken cancellationToken)
        {
            var validatorResult = _validator.Validate(request);
            if(!validatorResult.IsValid)
            {
                return new DownloadVideoResponseMessage(validatorResult);
            }

            var video = await _repository.GetByIdAsync<Video>(request.VideoId);
            var uri = video.LinkedFile.Uri;

            if(video.LinkedFile == null)
                return new DownloadVideoResponseMessage(validatorResult);
            if (string.IsNullOrEmpty(uri))
                return new DownloadVideoResponseMessage(validatorResult);

            var data = await _videoFileStorage.DownloadVideo(video.LinkedFile.Uri);

            return new DownloadVideoResponseMessage(validatorResult, video.Id, data);
        }
    }

    public class DownloadVideoResponseMessageValidator : AbstractValidator<DownloadVideoRequestMessage>
    {
        public DownloadVideoResponseMessageValidator()
        {
            RuleFor(r => r.VideoId).NotEmpty();
        }
    }

    public class DownloadVideoRequestMessage : IRequest<DownloadVideoResponseMessage>
    {
        public int VideoId { get; set; }
    }

    public class DownloadVideoResponseMessage
    {
        public ValidationResult ValidationResult { get; private set; }
        public DownloadVideoResponseMessage(ValidationResult validationResult, int? videoId = null, byte[] data = default)
        {
            this.ValidationResult = validationResult;
            VideoId = videoId;
            Data = data;
        }
        public int? VideoId { get; private set; }
        public byte[] Data { get; private set; }
    }
}
