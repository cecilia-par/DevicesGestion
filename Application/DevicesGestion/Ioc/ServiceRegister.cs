using Autofac;
using DevicesGestion.Adapter;
using DevicesGestion.Infrastructure;
using DevicesGestion.Services;
using DevicesGestion.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace DevicesGestion
{
    /// <summary>
    /// Classe qui permet d'enregister les services
    /// </summary>
    public static class ServiceRegister
    {
        public static IContainer Container;

        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ProgramAdapter>();
            builder.RegisterType<ValidateService>().As<IValidateService<IEnumerable<string>>>();
            builder.RegisterType<ConvertService>().As<IConvertService>();
            builder.RegisterType<DijkstraAdapter>().As<IShortestPathService>();
            builder.RegisterType<DijkstraService<string>>().As<IDijkstraService<string>>();
            Container = builder.Build();
        }
    }
}
