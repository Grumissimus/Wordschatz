using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wordschatz.Application.CommandHandlers;
using Wordschatz.Application.Commands.Dictionaries;
using Wordschatz.Application.Interfaces;
using Wordschatz.Application.Queries.Dictionaries;
using Wordschatz.Application.QueryHandlers;
using Wordschatz.Common.Commands;
using Wordschatz.Common.Queries;
using Wordschatz.Domain.Models.Dictionaries;
using Wordschatz.Infrastructure.Context;

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
            services.AddControllers();
            services.AddDbContext<WordschatzContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WordschatzDatabase")));

            services.AddScoped<ICommandHandlerService, DictionaryCommandHandler>();
            services.AddScoped<IQueryHandlerService, DictionaryQueryHandler>();

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
