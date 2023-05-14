using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.FeatureManagement;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess;
using SomeWhereCinema.WebApi.DotNet7.Controllers;

var builder = WebApplication.CreateBuilder(args);

// add feature management to enable feature flag. 
builder.Services.AddFeatureManagement();

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
builder.Services.AddDbContext<MovieDbContext>(
    // options => options.UseSqlite("Data source=db.db")
    options => options.UseMySql(
        "server=localhost;Port=3306;uid=user;pwd=12345678;database=somewherecinema",
        new MySqlServerVersion(new Version(8,0,33))
        )
    );



// Add Dependency Injection into web application
SomeWhereCinema.Application.DependencyResolver.DependencyResolverService.RegisterApplicationLayer(builder.Services);
SomeWhereCinema.DataAccess.DependencyResolver.DependencyResolverService.RegisterInfrastructureLayer(builder.Services);

// add cros
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(option =>
        {
            option.AllowAnyOrigin();
            option.AllowAnyHeader();
            option.AllowAnyMethod();
        });
}
app.UseSwagger();
app.UseSwaggerUI();
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