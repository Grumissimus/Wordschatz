using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wordschatz.Infrastructure.Context;
using MediatR;
using Wordschatz.Common.Commands;
using Wordschatz.API.Buses;
using Wordschatz.Common.Queries;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Wordschatz.API
{
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

            services.AddControllers()
                .AddFluentValidation(
                    fv => {
                        fv.RegisterValidatorsFromAssemblyContaining<Startup>();
                    }
                );

            services.AddDbContext<WordschatzContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WordschatzDatabase")));

            services.AddSingleton<ICommandBus, CommandBus>();
            services.AddSingleton<IQueryBus, QueryBus>();

            IoC.Build(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
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
