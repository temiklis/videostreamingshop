using Autofac;
using MediatR;
using VideoStreamingShop.Application.Usecases.Storage;
using VideoStreamingShop.Application.Usecases.Videocases;

namespace VideoStreamingShop.Infrasturcture.Modules
{
    internal class MediatorModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateVideoIteractor).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(UploadImagesForVideoInteractor).Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));
        }
    }
}
