using Games_Storage;
using Games_Storage.Core;
using Games_Storage.Core.Repositories;
using Games_Storage.Core.Services;
using Games_Storage.Core.Services.IServices;
using Games_Storage.Persistence;
using Games_Storage.Persistence.Repositories;
using Games_Storage.Presentation.ExceptionHendler;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Games_Storage.Core.Services.Mapper.MappingProfiles;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configHelper = new ConfigHelper(builder.Configuration);
var connectionString = configHelper.GetDefaultConnectionString();
builder.Services.AddDbContext<SqlDatabaseContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IStudioService, StudioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandler>();

app.UseAuthorization();

app.MapControllers();

app.Run();
