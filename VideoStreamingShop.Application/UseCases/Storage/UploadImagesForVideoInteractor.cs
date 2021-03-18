using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Application.Commands.Storage;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.Storage;

namespace VideoStreamingShop.Application.Usecases.Storage
{
    /// <summary>
    /// Upload images for video to the storage.
    /// </summary>
    public sealed class UploadImagesForVideoInteractor : IRequestHandler<UploadImagesForVideoRequestMessage, UploadImagesForVideoResponseMessage>
    {
        private readonly IImageStorage _imageStorage;
        private readonly IValidator<UploadImagesForVideoRequestMessage> _validator;
        private readonly IRepository _repository;
        public UploadImagesForVideoInteractor(IImageStorage imageStorage, IValidator<UploadImagesForVideoRequestMessage> validator, 
            IRepository repository)
        {
            _imageStorage = imageStorage;
            _validator = validator;
            _repository = repository;
        }
        public async Task<UploadImagesForVideoResponseMessage> Handle(UploadImagesForVideoRequestMessage request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return new UploadImagesForVideoResponseMessage(validationResult);

            var video = await _repository.GetByIdAsync<Video>(request.VideoId);

            if (video == null)
            {
                //remove that after testing
                validationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("video", "not found 404"));
                return new UploadImagesForVideoResponseMessage(validationResult);
            }

            List<string> imageUris = new List<string>();
            foreach (var data in request.FilesData)
            {
                var uri = await _imageStorage.Upload(data);

                var image = new VideoImage(Guid.NewGuid().ToString(), uri);

                imageUris.Add(uri);

                video.RegisterImage(image);
                await _repository.AddAsync<Video>(video);
            }

            return new UploadImagesForVideoResponseMessage(validationResult, imageUris);
        }
    }

}
