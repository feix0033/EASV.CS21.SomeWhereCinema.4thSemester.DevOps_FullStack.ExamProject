using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Application.Service;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess;
using SomeWhereCinema.DataAccess.Repository;
using SomeWhereCinema.WebApi.DotNet7.Controllers;

var builder = WebApplication.CreateBuilder(args);

// use auto mapper package to map the dtoes and entities.
builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton(
    new MapperConfiguration(conf => 
        { 
            conf.CreateMap<MoiveDTO, Movie>(); 
        })
            .CreateMapper()
    );

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 

// Setup Database Context
builder.Services.AddDbContext<MovieDbContext>(options => options.UseSqlite(
    "Data source=db.db"
));

// Add Dependency Injection into web application
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

// add cros
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(option =>
{
    option.AllowAnyOrigin();
    option.AllowAnyHeader();
    option.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();