using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.DotNet7.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController:ControllerBase
{
    private readonly IMovieService _movieService;
    // private readonly IValidator<MovieDto> _movieValidator;
    // private readonly IMapper _mapper;

    // Dependency Injection Interface to call the real Service
    public MovieController(
        IMovieService movieService
        // IMapper mapper, 
        // IValidator<MovieDto> movieValidator
        )
    {
        _movieService = movieService;
        // _movieValidator = movieValidator;
        // _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAllMovie")]
    public List<Movie> GetAll()
    {
        return _movieService.GetAllMovies();
    }

    [HttpPost]
    [Route("CreateMovie")]
    public Movie CreateMovie(Movie movie)
    {
        return _movieService.CreateMovie(movie);
        // try
        // {
        //     var movie = _movieService.CreateMovie(_mapper.Map<Movie>(dto));
        //     return Created("MovieTable/" + movie.Id, movie);
        // }
        // catch (ValidationException e)
        // {
        //     return BadRequest(e.Message);
        // }
        // catch (Exception e)
        // {
        //     return StatusCode(500, e.Message);
        // }
    }
    

    [HttpPatch] // change some of preperties in database but not all record.
    [Route("ReadMovie")]
    public Movie ReadMovie(Movie movie)
    {
        return _movieService.ReadMovie(movie);
        // try
        // {
        //     return Ok(_movieService.ReadMovie(_mapper.Map<Movie>(dto)));
        // }
        // catch (Exception e)
        // {
        //     return BadRequest(e.Message);
        // }
    }
    
    
    
    [HttpPut]
    [Route("UpdateMovie")]
    public Movie UpdateMovie(Movie movie)
    {
        return _movieService.UpdateMovie(movie);
        // var validationResult = _movieValidator.Validate(dto);
        // if (validationResult.IsValid)
        // {
        //     return Ok(_movieService.UpdateMovie(_mapper.Map<Movie>(dto)));
        // }
        // return BadRequest(validationResult.ToString());
    }

    [HttpDelete]
    [Route("DeleteMovie")]
    public Movie DeleteMovie(Movie movie)
    {
        return _movieService.DeleteMovie(movie);
    }
    
}