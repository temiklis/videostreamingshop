using Autofac;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Usecases.Storage;
using VideoStreamingShop.Core.Usecases.Videocases;

namespace VideoStreamingShop.Infrasturcture.Modules
{
    public class FluentValidationModule : Autofac.Module
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
