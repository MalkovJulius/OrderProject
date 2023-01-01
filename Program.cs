using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OrderProject.Data;
using OrderProject.Data.ContractorData;
using OrderProject.Data.CustomerData;
using OrderProject.Data.OrderData;
using OrderProject.Data.OutsourcingCompanyData;
using OrderProject.Services.ContractorService;
using OrderProject.Services.CustomerService;
using OrderProject.Services.OrderService;
using OrderProject.Services.OutsourcingCompanyService;
using System;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("OrderProjectConnection")));

// Add services to the container. Add JSON Serializer.
// TODO: I should think about AddControllers and CamelCasePropertyNamesContractResolver
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

//JSON Serializer-------------------------
builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(option =>
        option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
    .AddNewtonsoftJson(option =>
        option.SerializerSettings.ContractResolver = new DefaultContractResolver());
builder.Services.AddControllers()
    .AddNewtonsoftJson(s =>
        s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

// Injected repositories
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICustomerRepo, SqlCustomerRepo>();
builder.Services.AddScoped<IContractorRepo, SqlContractorRepo>();
builder.Services.AddScoped<IOrderRepo, SqlOrderRepo>();
builder.Services.AddScoped<IOutsourcingCompanyRepo, SqlOutsourcingCompanyRepo>();

// Injected services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IContractorService, ContractorService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOutsourcingCompanyService, OutsourcingCompanyService>();

//Enable CORS-----------------
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", option => option
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

//Enable CORS---------------------
app.UseCors(option => option
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
}

app.UseStaticFiles();
//app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseRouting();
app.UseAuthorization();

//TODO: should look into this issue. Endpoint and ControllerRoute.
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();