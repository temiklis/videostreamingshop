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
using VideoStreamingShop.Core.Interfaces.Storage;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
    public class CreateVideoIteractor : IRequestHandler<CreateVideoRequestMessage, CreateVideoResponseMessage>
    {
        //need to add automapper here
        private readonly IRepository _repository;
        private readonly IValidator<CreateVideoRequestMessage> _validator;
        public CreateVideoIteractor(IRepository repository, IValidator<CreateVideoRequestMessage> validator)
        {
            _validator = validator;
            _repository = repository;
        }
        public async Task<CreateVideoResponseMessage> Handle(CreateVideoRequestMessage request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return new CreateVideoResponseMessage(validationResult);

            var video = new Video()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                AgeRate = request.AgeRate,
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
        public decimal Price { get; set; }
        public AgeRating AgeRate { get; set; }
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
