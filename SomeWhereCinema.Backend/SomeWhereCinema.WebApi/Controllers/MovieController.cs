using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess;

namespace SomeWhereCinema.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController:ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService ?? 
                        throw new InvalidDataException("movieService can not be null.");
    }

    [HttpGet]
    public object GetAll()
    {
        var movies = _movieService.GetMovies();
        return "hellow";
    }
}