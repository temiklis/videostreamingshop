using Autofac;
using FluentValidation;
using VideoStreamingShop.Application.Validations.Storage;
using VideoStreamingShop.Application.Validations.Video;

namespace VideoStreamingShop.Infrasturcture.Modules
{
    internal class FluentValidationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IValidator).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(
                typeof(DownloadVideoResponseMessageValidator).Assembly,
                typeof(UploadVideoRequestMessageValidator).Assembly,
                typeof(CreateVideoRequestMessageValidator).Assembly,
                typeof(UploadImagesForVideoValidator).Assembly)
                .AsClosedTypesOf(typeof(IValidator<>));
        }
    }
}
