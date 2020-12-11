using Autofac;
using Autofac.Core;
using Autofac.Features.AttributeFilters;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VideoStreamingShop.Core.Entities;
using VideoStreamingShop.Core.Infrascturucre;
using VideoStreamingShop.Core.Interfaces;
using VideoStreamingShop.Core.Interfaces.FileExtensions;
using VideoStreamingShop.Core.Interfaces.Storage;
using VideoStreamingShop.Core.Usecases;
using VideoStreamingShop.Core.Usecases.Storage;
using VideoStreamingShop.Core.Usecases.Videocases;
using VideoStreamingShop.Infrasturcture.Data;
using VideoStreamingShop.Infrasturcture.Services;
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
            }
            else
            {
                LoadProductionDependencies(builder);
            }

            LoadCommonDependensies(builder);
        }

        private void LoadCommonDependensies(ContainerBuilder builder)
        {
        }

        private void LoadProductionDependencies(ContainerBuilder builder)
        {
            
        }

        private void LoadDevelopmentDependencies(ContainerBuilder builder)
        {

            builder
                .RegisterType<MimeShiffing>()
                .As<IMimeShiffing>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ImageFileExtension>()
                .Keyed<IFileExtension>(FileType.Image)
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(List<Extension>),
                    (p, c) => new List<Extension>()
                    { 
                        Extension.JPEG, 
                        Extension.PNG 
                    });

            builder.RegisterType<VideoFileExtension>()
                .Keyed<IFileExtension>(FileType.Video)
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(List<Extension>),
                    (p, c) => new List<Extension>()
                    {
                        Extension.MP4,
                        Extension.AVI
                    });

            LoadStoragies(builder);

            builder
                .RegisterType<VideoService>()
                .As<IVideoService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DownloadVideoResponseMessageValidator>()
                .As<IValidator<DownloadVideoRequestMessage>>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<UploadVideoRequestMessageValidator>()
                .As<IValidator<UploadVideoRequestMessage>>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<CreateVideoRequestMessageValidator>()
                .As<IValidator<CreateVideoRequestMessage>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UploadImagesForVideoValidator>()
                .As<IValidator<UploadImagesForVideoRequestMessage>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UploadImagesForVideoInteractor>()
                .WithAttributeFiltering();

            builder.RegisterType<UploadVideoIteractor>()
                .WithAttributeFiltering();

            builder.RegisterType<CvsFileExtensionTranslator>()
                .As<IFileExtensionTranslator>()
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(string) && p.Name == "pathToTranslationFile",
                    (p, c) => "AppFolder/Csv/meme1.csv")
                .InstancePerLifetimeScope();
        }
        private static void LoadStoragies(ContainerBuilder builder)
        {
            builder.
                RegisterType<LocalImageStorage>()
                .As<IImageStorage>()
                .WithParameter(
                    (p, c) => p.ParameterType == typeof(string) && p.Name == "storagePath",
                    (p, c) => "AppFolder/Images"
                )
                .InstancePerLifetimeScope();
            builder
                .RegisterType<MockDataRepository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<LocalVideoStorage>()
                .As<IVideoFileStorage>()
                .WithParameter(
                 (p, c) => p.ParameterType == typeof(string) && p.Name == "path",
                 (p, c) => "AppFolder"
                )
                .InstancePerLifetimeScope();
        }
    }
}
