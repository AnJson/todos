using Todos.Models;
using Todos.Interfaces;
using Todos.Repositories;
using Todos.Services;
using Microsoft.Extensions.Options;
using Todos.Model.Auth;
using Todos.Config;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the containers.
builder.Services.Configure<MongoDbSettings>(
    builder.Configuration.GetSection(nameof(MongoDbSettings)));

// MONGODB.
builder.Services
    .AddSingleton<IMongoDbSettings>(serviceProvider =>
        serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value)
    .AddSingleton<IMongoDbContext, MongoDbContext>();

// TODO.
builder.Services
    .AddScoped<ITodoRepository, TodoRepository>()
    .AddScoped<ITodoService, TodoService>();

// AUTH.
builder.Services
    .AddScoped<IAuthRepository, AuthRepository>()
    .AddScoped<IAuthService, AuthService>();

// AUTOMAPPER.
builder.Services.AddAutoMapper(typeof(MapperConfig));

{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}


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
