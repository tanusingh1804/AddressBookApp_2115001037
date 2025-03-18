using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using ModelLayer.DTO;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model.Validation;
using Microsoft.OpenApi.Models;
using BusinessLayer.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the DI container
builder.Services.AddControllers();

// AutoMapper Configuration
builder.Services.AddAutoMapper(typeof(AutomapperProfile));

// Register Business Layer Services
builder.Services.AddScoped<IAddressBookService, AddressBookService>();

// Register Repository Layer Services
builder.Services.AddScoped<IAddressRL, AddressRL>();

// FluentValidation Registration
builder.Services.AddValidatorsFromAssemblyContaining<AddressBookDTO>();
builder.Services.AddScoped<IValidator<AddressBookDTO>, AddressBookValidator>();

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AddressBook API", Version = "v1" });
});

var app = builder.Build();

// Configure Middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AddressBook API v1"));
}

app.UseRouting();
app.UseAuthorization();

app.MapControllers();
app.Run();
