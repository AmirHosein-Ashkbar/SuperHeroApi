global using SuperHeroApi.Models;
global using SuperHeroApi.Data;
using SuperHeroApi.Services.SuperHeroService;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SuperHeroApi.DTO;
using SuperHeroApi.Validations;
using SuperHeroApi.Common;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

//adding fluent validation
builder.Services.AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
