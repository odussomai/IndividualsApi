﻿using AutoMapper;
using IndividualsApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<IndividualsContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:IndividualsConnectionString"]));
            services.AddScoped<IIndividualsRepository, IndividualRepository>();
            services.AddAutoMapper(typeof(Startup));

            services.AddSwaggerGen(setup =>
            {
                setup.SwaggerDoc("IndividualsSpec", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Individuals API"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI(opt =>
            {
                opt.SwaggerEndpoint("/swagger/IndividualsSpec/swagger.json", "Individuals API");
                opt.RoutePrefix = "";
            });
            app.UseMvc();
        }
    }
}