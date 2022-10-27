using Todos.Models;
using Todos.Interfaces;
using Todos.Repositories;
using Todos.Services;
using Microsoft.Extensions.Options;
using Todos.Model.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the containers.
// TODOS.
builder.Services.Configure<TodoDbSettings>(
    builder.Configuration.GetSection(nameof(TodoDbSettings)));

builder.Services
    .AddSingleton<ITodoDbSettings>(serviceProvider =>
        serviceProvider.GetRequiredService<IOptions<TodoDbSettings>>().Value)
    .AddSingleton<IMongoDbContext, MongoDbContext>()
    .AddScoped<ITodoRepository, TodoRepository>()
    .AddScoped<ITodoService, TodoService>();

// AUTH
builder.Services.Configure<AuthDbSettings>(
    builder.Configuration.GetSection(nameof(AuthDbSettings)));

builder.Services
    .AddSingleton<IAuthDbSettings>(serviceProvider =>
        serviceProvider.GetRequiredService<IOptions<AuthDbSettings>>().Value)
    .AddSingleton<IMongoDbContext, MongoDbContext>()
    .AddScoped<IAuthRepository, AuthRepository>()
    .AddScoped<IAuthService, AuthService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<JsonFileTodoService>();


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
