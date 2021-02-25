using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.Storage;
using VideoStreamingShop.Infrasturcture.Data;
using VideoStreamingShop.Infrasturcture.Services;

namespace VideoStreamingShop.Infrasturcture.Modules
{
    public class StorageModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.
               RegisterType<LocalImageStorage>()
               .As<IImageStorage>()
               .WithParameter(
                   (p, c) => p.ParameterType == typeof(string) && p.Name == "storagePath",
                   (p, c) => "AppFolder/Images")
               .InstancePerLifetimeScope();

            builder
                .RegisterType<EFRepository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<LocalVideoStorage>()
                .As<IVideoFileStorage>()
                .WithParameter(
                 (p, c) => p.ParameterType == typeof(string) && p.Name == "path",
                 (p, c) => "AppFolder")
                .InstancePerLifetimeScope();
        }
    }
}
