using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wordschatz.Infrastructure.Context;
using MediatR;
using System.Reflection;
using Wordschatz.Common.Commands;
using Wordschatz.API.Buses;
using Wordschatz.Common.Queries;
using System;
using System.Linq;

using Wordschatz.Application;
using Wordschatz.Application.Dictionaries.Commands;
using Wordschatz.Application.Dictionaries.CommandHandlers;
using Wordschatz.Application.Dictionaries.QueryHandlers;
using Wordschatz.Application.Dictionaries.Queries;
using Wordschatz.Domain.Models.Dictionaries;
using System.Collections.Generic;

namespace Wordschatz.API
{
    public static class ServiceExtensions
    {
        public static void AddCommandQueryHandlers(this IServiceCollection services, Type handlerInterface)
        {
            var handlers = Assembly.GetExecutingAssembly().GetTypes().Where(t => (t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface)));

            Console.WriteLine( handlers.Count() );

            foreach (var handler in handlers)
            {
                Console.WriteLine(handler.Name);
                services.AddScoped(handler.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterface), handler);
            }
        }
    }

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();

            services.AddDbContext<WordschatzContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WordschatzDatabase")));

            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddSingleton<ICommandBus, CommandBus>();
            services.AddSingleton<IQueryBus, QueryBus>();

            IoC.Build(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
