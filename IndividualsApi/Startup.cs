using AutoMapper;
using IndividualsApi.Data;
using IndividualsApi.Data.Interfaces;
using IndividualsApi.Extensions;
using IndividualsApi.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IndividualsApi.Data.Services;
using IndividualsApi.Resources;
using Newtonsoft.Json;

namespace IndividualsApi
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
            
            services.AddDbContext<IndividualsContext>(opts => opts.UseSqlServer(Configuration.GetConnectionString("IndividualsConnectionString")));
            services.AddScoped<IIndividualsRepository, IndividualRepository>();
            services.AddScoped<ModelValidationFilter>();
            services.AddLogging();
            services.AddAutoMapper(typeof(Startup));
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddDataAnnotationsLocalization(o =>
                {
                    o.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource));
                })
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                }); ;


            services.AddTransient<IImageHandler, ImageHandler>();
            services.AddTransient<IImageWriter, ImageWriter>();

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("IndividualsSpec", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Individuals API"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ILogger<Startup> logger)
        {
            app.UseCultureHeaderMiddleware();
            app.ConfigureCustomExceptionMiddleware();

            loggerFactory.AddFile("Logs/IndividualsApi-{Date}.txt");

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/IndividualsSpec/swagger.json", "Individuals API");
                opt.RoutePrefix = "";
            });
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
