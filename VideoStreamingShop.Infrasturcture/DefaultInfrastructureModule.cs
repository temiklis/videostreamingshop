using Autofac;
using System.Collections.Generic;
using System.Reflection;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Infrascturucre;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.FileExtensions;
using VideoStreamingShop.Infrasturcture.Modules;
using VideoStreamingShop.Infrasturcture.Services;
using VideoStreamingShop.Infrasturcture.Services.FileExtensions;
using Module = Autofac.Module;

namespace VideoStreamingShop.Infrasturcture
{
    public class DefaultInfrastructureModule : Module
    {
        private bool _isDevelopment = false;

        private List<Assembly> assemblies = new List<Assembly>();
        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
        }
        protected override void Load(Autofac.ContainerBuilder builder)
        {
            if(_isDevelopment)
            {
                LoadDevelopmentDependencies(builder);
                builder.RegisterModule(new StorageModule());
            }
            else
            {
                LoadProductionDependencies(builder);
            }

            LoadCommonDependensies(builder);
        }

        private void LoadCommonDependensies(ContainerBuilder builder)
        {
            builder.RegisterModule(new MediatorModule());
            builder.RegisterModule(new FluentValidationModule());
            builder.RegisterModule(new StorageModule());
        }

        private void LoadProductionDependencies(ContainerBuilder builder)
        {
            
        }

        private void LoadDevelopmentDependencies(ContainerBuilder builder)
        {

            builder.RegisterType<MimeShiffing>()
                .As<IMimeShiffing>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ImageFileExtension>()
                .Keyed<IFileExtension>(FileType.Image)
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(List<Extension>),
                    (p, c) => new List<Extension>()
                    {
                        Extension.JPEG,
                        Extension.PNG
                    })
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<VideoFileExtension>()
                .Keyed<IFileExtension>(FileType.Video)
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(List<Extension>),
                    (p, c) => new List<Extension>()
                    {
                        Extension.MP4,
                        Extension.AVI
                    })
                .InstancePerLifetimeScope();

            builder.RegisterType<VideoService>()
                .As<IVideoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CvsFileExtensionTranslator>()
                .As<IFileExtensionTranslator>()
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(string) && p.Name == "pathToTranslationFile",
                    (p, c) => @"VideoStreamingShop.Infrasturcture.Data.FileTranslator.csv.Formats.csv")
                .InstancePerLifetimeScope();
        }
    }
}
