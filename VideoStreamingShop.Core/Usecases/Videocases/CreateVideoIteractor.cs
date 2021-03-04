using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;

namespace VideoStreamingShop.Core.Usecases.Videocases
{
    /// <summary>
    /// Create video in the database 
    /// </summary>
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
}
