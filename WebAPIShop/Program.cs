using Microsoft.EntityFrameworkCore;
using Repository;
using Servers;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddDbContext<db_shopContext>(option=>option.UseSqlServer
("Data Source = srv2\\pupils; Initial Catalog = 215806571_shop; Integrated Security = True; Trust Server Certificate=True"));



// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
