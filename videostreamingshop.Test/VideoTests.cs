using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using NUnit.Framework;
using VideoStreamingShop.Application.Commands.Video;
using VideoStreamingShop.Application.Usecases.Videocases;
using VideoStreamingShop.Application.Validations.Video;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Interfaces;

namespace videostreamingshop.Core.Test
{
    public class VideoTests
    {
        Mock<IRepository> mockRepository;

        [SetUp]
        public void SetUp()
        {
            mockRepository = new Mock<IRepository>();
        }

        [Test]
        public async Task CreateVideoTest() 
        {
            var video = new CreateVideoRequestMessage()
            {
                Name = "Call of the wild",
                Price = 12.99M,
                AgeRate = AgeRating.G,
                Description = "Test description"
            };

            mockRepository.Setup(rep => rep.AddAsync(It.IsAny<Video>()))
                .Returns(Task.FromResult(new Video()
                {
                    Id = 1
                }));

            var mockValidator = new Mock<IValidator<CreateVideoRequestMessage>>();
            mockValidator.Setup(vl => vl.Validate(video)).Returns(new ValidationResult());

            var createVideoIteractor = new CreateVideoIteractor(mockRepository.Object, mockValidator.Object);

            var result = await createVideoIteractor.Handle(video, CancellationToken.None);

            Assert.IsNotNull(result.VideoId);
        }

        [Test]
        public async Task CreateVideoWithEmtyRequest()
        {
            var request = new CreateVideoRequestMessage();
            mockRepository.Setup(rep => rep.AddAsync(It.IsAny<Video>()))
                .Returns(Task.FromResult((Video)null));
            

            var validations = new CreateVideoRequestMessageValidator();

            var createVideoIteractor = new CreateVideoIteractor(mockRepository.Object, validations);

            var result = await createVideoIteractor.Handle(request, CancellationToken.None);

            Assert.Greater(result.ValidationResult.Errors.Count, 0);
            Assert.IsNull(result.VideoId);
        }
    }
}
