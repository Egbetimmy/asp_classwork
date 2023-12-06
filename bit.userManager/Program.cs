using bit.userManager.IRepository;
using bit.userManager.Models;
using bit.userManager.Repository;
using bit.userManager.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//Add dbcontext
builder.Services.AddDbContext<MyDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbContext")));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Add(new ServiceDescriptor(typeof(IUser), new UserService()));
//builder.Services.Add(new ServiceDescriptor(typeof(IAccount), new Account()));


builder.Services.AddScoped<UserServiceClass, UserServiceClass>();
builder.Services.AddScoped<IUser, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
