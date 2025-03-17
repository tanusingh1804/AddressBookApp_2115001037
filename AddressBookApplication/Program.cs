using RepositoryLayer.Context;
using BusinessLayer.Interface;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;
using BusinessLayer.Validation;
using BusinessLayer.Service;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// **Ensure Database Connection is Set**
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); // Fixed key name
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Database connection string is missing!");
}

Console.WriteLine($"Connection String: {connectionString}"); // Debugging Purpose

builder.Services.AddDbContext<AddressContext>(options =>
    options.UseSqlServer(connectionString));

// **Register Services**
builder.Services.AddScoped<IAddressBookBL, AddressBL>();
builder.Services.AddScoped<IAddressRL, AddressRL>();

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();   
builder.Services.AddAuthentication();

// **AutoMapper Setup**
builder.Services.AddAutoMapper(typeof(AutomapperProfile));

// **Fluent Validation**
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<AddressBookValidator>();

var app = builder.Build();

// **Middleware Configuration**
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
