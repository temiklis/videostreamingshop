using Autofac;
using Autofac.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VideoStreamingShop.Core.Interfaces;
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
                .RegisterType<MockDataRepository>()
                .As<IRepository>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<VideoService>()
                .As<IVideoService>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<LocalVideoStorage>()
                .As<IVideoFileStorage>()
                .WithParameter(
                 (p, c) => p.ParameterType == typeof(string) && p.Name == "path",
                 (p, c) => "AppFolder"
                )
                .InstancePerLifetimeScope();
            builder.RegisterType<DownloadVideoResponseMessageValidator>()
                .As<IValidator<DownloadVideoRequestMessage>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<UploadVideoRequestMessageValidator>()
                .As<IValidator<UploadVideoRequestMessage>>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CreateVideoRequestMessageValidator>()
                .As<IValidator<CreateVideoRequestMessage>>();        
        }
    }
}
