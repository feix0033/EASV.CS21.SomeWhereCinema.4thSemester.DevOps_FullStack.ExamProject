using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.DotNet7.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController:ControllerBase
{
    private readonly IMovieService _movieService;
    private readonly IValidator<MoiveDTO> _movieValidator;
    private readonly IMapper _mapper;

    // Dependency Injection Interface to call the real Service
    public MovieController(IMovieService movieService, IMapper mapper, IValidator<MoiveDTO> movieValidator)
    {
        _movieService = movieService;
        _movieValidator = movieValidator;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAllMovie")]
    public ActionResult<List<Movie>> GetAll()
    {
        return Ok(_movieService.GetMovies());
    }

    [HttpPost]
    [Route("CreateMovie")]
    public ActionResult<Movie> CreateMovie(MoiveDTO dto)
    {
        try
        {
            var movie = _movieService.CreateMovie(_mapper.Map<Movie>(dto));
            return Created("Movie/" + movie.Id, movie);
        }
        catch (ValidationException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    

    [HttpPatch] // change some of preperties in database but not all record.
    [Route("ReadMovie")]
    public ActionResult<Movie> ReadMovie(Movie movie)
    {
        try
        {
            return Ok(_movieService.ReadMovie(movie));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
    
    [HttpPut]
    [Route("UpdateMovie")]
    public ActionResult<Movie> UpdateMovie(MoiveDTO dto)
    {
        var validationResult = _movieValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            return Ok(_movieService.UpdateMovie(_mapper.Map<Movie>(dto)));
        }
        return BadRequest(validationResult.ToString());
    }

    [HttpDelete]
    [Route("{name}")]
    public ActionResult<Movie> DeleteMovie(string name)
    {
        var movie = new Movie()
        {
            Name = name
        };
        return Ok(_movieService.DeleteMovie(movie));
    }

    [HttpGet]
    [Route("CreateDatabase")]
    public ActionResult<string> CreateDb()
    {
        _movieService.ReInitDb();
        return Ok("Database has been created");
    }
}