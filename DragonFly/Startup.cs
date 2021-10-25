using DragonFly.Context;
using DragonFly.Domain.Entities;
using DragonFly.Domain.Interfaces;
using DragonFly.Infrastructure.Data;
using DragonFly.Services;
using DragonFly.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonFly
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IServiceCollection _services { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
            services.AddControllers();

            services.Configure<ConnectionString>(Configuration.GetSection("ConnectionString"));
            services.AddDbContext<SqlServerContext>(options => options.UseSqlServer(Configuration["ConnectionString:MsSqlConnection"]));

            services.AddMvc();

            services.AddCors(options =>
            {
                options.AddPolicy("Policy1",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com",
                                            "http://www.contoso.com");
                    });

                options.AddPolicy("AnotherPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:44370/")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Samity App",
                    Version = "v1",
                    Description = "Personal project"
                });
            });
            services.AddControllers();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });


            services.AddHttpContextAccessor();

            //if services.AddHttpContextAccessor(); don't use then show below error

            //No database provider has been configured for this DbContext.
            //A provider can be configured by overriding the DbContext.OnConfiguring method or by using AddDbContext on the application service provider.
            //If AddDbContext is used, then also ensure that your DbContext type accepts a DbContextOptions<TContext> object in its constructor
            //and passes it to the base constructor for DbContext.

            //Dependency Injection part

            services.AddTransient<IMembersInformationService, MembersInformationService>();
            services.AddTransient<IMembersInformationRepository, MembersInformationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options => options.AllowAnyOrigin());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Personal project");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();
        }
    }
}
