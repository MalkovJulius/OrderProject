using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using OrderProject.Data;
using OrderProject.Data.ContractorData;
using OrderProject.Data.CustomerData;
using OrderProject.Data.OrderData;
using OrderProject.Data.OutsourcingCompanyData;
using OrderProject.Middlewares;
using OrderProject.Services.ContractorService;
using OrderProject.Services.CustomerService;
using OrderProject.Services.OrderService;
using OrderProject.Services.OutsourcingCompanyService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>(option =>
                option.UseSqlServer(Configuration.GetConnectionString("OrderProjectConnection")));

            //JSON Serializer-------------------------
            services.AddControllersWithViews()
                .AddNewtonsoftJson(option =>
                    option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(option =>
                    option.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddControllers()
                .AddNewtonsoftJson(s =>
                    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<ICustomerRepo, SqlCustomerRepo>();
            services.AddScoped<IContractorRepo, SqlContractorRepo>();
            services.AddScoped<IOrderRepo, SqlOrderRepo>();
            services.AddScoped<IOutsourcingCompanyRepo, SqlOutsourcingCompanyRepo>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IContractorService, ContractorService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOutsourcingCompanyService, OutsourcingCompanyService>();

            //Enable CORS-----------------
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", option => option
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Enable CORS---------------------
            app.UseCors(option => option
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Use files ---------------------------------
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "src")),
                RequestPath = "/ClientApp/src"
            });
        }
    }
}
