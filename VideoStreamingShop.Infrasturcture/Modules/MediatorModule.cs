using Autofac;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VideoStreamingShop.Core.Usecases.Videocases;

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
        }
    }
}
