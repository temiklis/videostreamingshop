using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Infrastructure.Commands.Storage;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.Storage;

namespace VideoStreamingShop.Core.Usecases.Storage
{
    /// <summary>
    /// Download video to storage.
    /// Use mediatR to access to this case.
    /// </summary>
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
}
