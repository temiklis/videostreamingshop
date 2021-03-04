using Autofac.Features.AttributeFilters;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Infrascturucre;
using VideoStreamingShop.Core.Infrastructure.Commands.Storage;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.FileExtensions;
using VideoStreamingShop.Core.Interfaces.Storage;

namespace VideoStreamingShop.Core.Usecases.Storage
{
    /// <summary>
    /// Upload video to the storage.
    /// </summary>
    public class UploadVideoIteractor : IRequestHandler<UploadVideoRequestMessage, UploadVideoResponseMessage>
    {
        private readonly IRepository _repository;
        private readonly IValidator<UploadVideoRequestMessage> _validator;
        private readonly IVideoFileStorage _videoFileStorage;
        private readonly IFileExtension _fileExtension;

        public UploadVideoIteractor(IRepository repository, IValidator<UploadVideoRequestMessage> validator, IVideoFileStorage videoFileStorage,
            [KeyFilter(FileType.Video)]IFileExtension fileExtension)
        {
            _repository = repository;
            _validator = validator;
            _videoFileStorage = videoFileStorage;
            _fileExtension = fileExtension;
        }
        public async Task<UploadVideoResponseMessage> Handle(UploadVideoRequestMessage request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                return new UploadVideoResponseMessage(validationResult);
            }

            if(!_fileExtension.Validate(request.Data))
            {
                validationResult.Errors.Add(new ValidationFailure("formatting", @"Format not supported"));
                return new UploadVideoResponseMessage(validationResult);
            }

            var video = await _repository.GetByIdAsync<Video>(request.VideoId);
            if(video == null)
            {
                validationResult.Errors.Add(new ValidationFailure("not exist", "video not exist"));
                return new UploadVideoResponseMessage(validationResult);
            }

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
}
