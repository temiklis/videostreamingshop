﻿using Autofac.Features.AttributeFilters;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Infrascturucre;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Core.Usecases.Storage
{
#warning Need some time for mind that.Because we need to save images to storage and connect it's to video. 
    public sealed class UploadImagesForVideoInteractor : IRequestHandler<UploadImagesForVideoRequestMessage, UploadImagesForVideoResponseMessage>
    {
        private readonly IImageStorage _imageStorage;
        private readonly IValidator<UploadImagesForVideoRequestMessage> _validator;
        private readonly IRepository _repository;
        private readonly IFileExtension _fileExtension;
        public UploadImagesForVideoInteractor(IImageStorage imageStorage, IValidator<UploadImagesForVideoRequestMessage> validator, 
            IRepository repository, [KeyFilter(FileType.Image)] IFileExtension fileExtension)
        {
            _imageStorage = imageStorage;
            _validator = validator;
            _repository = repository;
            _fileExtension = fileExtension;
        }
        public async Task<UploadImagesForVideoResponseMessage> Handle(UploadImagesForVideoRequestMessage request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return new UploadImagesForVideoResponseMessage(validationResult);

            var video = await _repository.GetByIdAsync<Video>(request.VideoId);

            if (video == null)
                return new UploadImagesForVideoResponseMessage(validationResult);

            List<string> imageUris = new List<string>();
            foreach (var data in request.FilesData)
            {
                if (_fileExtension.Validate(data))
                {
                    var uri = await _imageStorage.Upload(data);

                    var image = new VideoImage()
                    {
                        Name = Guid.NewGuid().ToString(),
                        Uri = uri
                    };

                    imageUris.Add(uri);

                    video.RegisterImage(image);
                    await _repository.AddAsync<Video>(video);
                }
            }

            return new UploadImagesForVideoResponseMessage(validationResult, imageUris);
        }
    }

    public class UploadImagesForVideoValidator : AbstractValidator<UploadImagesForVideoRequestMessage>
    {
        public UploadImagesForVideoValidator()
        {
            RuleFor(r => r.VideoId).NotEmpty() ;
            RuleFor(r => r.FilesData.Count).LessThan(4);
        }
    }

    public class UploadImagesForVideoRequestMessage : IRequest<UploadImagesForVideoResponseMessage>
    {
        public int VideoId { get; set; }
        public List<byte[]> FilesData { get; set; }
    }
    public class UploadImagesForVideoResponseMessage
    {
        public FluentValidation.Results.ValidationResult ValidationResult { get; private set; }
        public List<string> Paths { get; private set; }
        public UploadImagesForVideoResponseMessage(FluentValidation.Results.ValidationResult validationResult, List<string> paths = null)
        {
            ValidationResult = validationResult;
            Paths = paths;
        }
    }

}
