using Microsoft.EntityFrameworkCore;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Application.Service;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.DataAccess;
using SomeWhereCinema.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Setup Dependency Injection.
// builder.Services.AddScoped<IMovieService, MovieService>();
// builder.Services.AddScoped<IMovieRepository, MovieRepository>();

// Setting DB Info
// builder.Services.AddDbContext<MovieDbContext>(
//     option =>
//     {
//         option.UseSqlite("Data Source=main.db");
//     });


// builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
//     .AddNegotiate();

// builder.Services.AddAuthorization(options =>
// {
//     // By default, all incoming requests will be authorized according to the default policy.
//     options.FallbackPolicy = options.DefaultPolicy;
// });

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