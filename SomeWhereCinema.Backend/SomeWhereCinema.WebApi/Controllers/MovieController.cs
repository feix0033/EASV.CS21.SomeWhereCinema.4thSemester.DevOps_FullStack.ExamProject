using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController:ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService ?? 
                        throw new InvalidDataException("movieService can not be null.");
    }

    [HttpGet]
    public ActionResult<List<Movie>> GetAll()
    {
        return null;
    }
}