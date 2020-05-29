using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Wordschatz.Application.Dictionaries.QueryHandlers;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;

namespace Wordschatz.API
{
    public static class IoC
    {
        public static IContainer Container { get; set; }

        public static void Configure()
        {
            var builder = new ContainerBuilder();
            Assembly assemblies = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsInNamespace("Wordschatz.Application") && t.IsAssignableFrom(typeof(ICommandHandler<>)))
                .AsSelf()
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsInNamespace("Wordschatz.Application") && t.IsAssignableFrom(typeof(IQueryHandler<,>)))
                .AsSelf()
                .AsImplementedInterfaces();

            Container = builder.Build();
        }
    }
}
