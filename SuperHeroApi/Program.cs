global using SuperHeroApi.Models;
global using SuperHeroApi.Data;
using SuperHeroApi.Services.SuperHeroService;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using SuperHeroApi.DTO;
using SuperHeroApi.Validations;
using SuperHeroApi.Common;
using FluentValidation.AspNetCore;
using SuperHeroApi.Services.LeagueService;
using SuperHeroApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
builder.Services.AddScoped<ILeagueService, LeagueService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));


//adding fluent validation
builder.Services.AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<IAssemblyMarker>();

builder.Services.AddAutoMapper(typeof(Program));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

//app.UseMiddleware<TimingMiddleware>();
//app.UseTiming();

//app.UseMiddleware<ErrorHandlingMiddleware>();

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
