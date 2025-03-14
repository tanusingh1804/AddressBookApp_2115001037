using Microsoft.EntityFrameworkCore;
using AddressBookApplication.RepositoryLayer.Context;
using AddressBookApplication.RepositoryLayer.Interface;
using AddressBookApplication.RepositoryLayer.Service;

var builder = WebApplication.CreateBuilder(args);

 //Connection String NULL na ho iske liye check karo
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AddressContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IAddressRL, AddressRL>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
