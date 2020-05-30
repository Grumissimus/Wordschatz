﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
using Wordschatz.Infrastructure.Context;

namespace Wordschatz.API
{
    public static class IoC
    {
        public static IContainer Container { get; set; }

        public static void Build(IServiceCollection services)
        {
            var builder = new ContainerBuilder();

            builder.Populate(services);

            var handlers = Assembly.Load("Wordschatz.Application");

            builder.RegisterAssemblyTypes(handlers)
            .AsClosedTypesOf(typeof(ICommandHandler<>))
            .InstancePerDependency();

            builder.RegisterAssemblyTypes(handlers)
            .AsClosedTypesOf(typeof(IQueryHandler<,>))
            .InstancePerDependency();
            
            Container = builder.Build();
        }
    }
}
