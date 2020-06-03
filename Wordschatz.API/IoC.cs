using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;

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
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(handlers)
                .AsClosedTypesOf(typeof(IQueryHandler<,>))
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(handlers)
                .AsClosedTypesOf(typeof(IValidator<>))
                .InstancePerLifetimeScope();

            Container = builder.Build();
        }
    }
}