using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.DotNet7.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController:ControllerBase
{
    private IMovieRepository _movieRepository;
    private MovieValidator _movieValidator;
    private readonly IMapper _mapper;

    // Dependency Injection Interface to call the real Service
    public MovieController(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _movieValidator = new MovieValidator();
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetAllMovie")]
    public ActionResult<List<Movie>> GetAll()
    {
        return Ok(_movieRepository.FindAll());
    }

    [HttpPost]
    [Route("CreateMovie")]
    public ActionResult<Movie> CreateMovie(MoiveDTO dto)
    {
        
        var valid = _movieValidator.Validate(dto);
        if (valid.IsValid)
        {
            return Ok(_movieRepository.CreateMovie(_mapper.Map<Movie>(dto)));
        }

        return BadRequest(valid.ToString());
    }

    [HttpPut]
    [Route("ReadMovie")]
    public ActionResult<Movie> ReadMovie(Movie movie)
    {
        return Ok(_movieRepository.ReadMovie(movie));
    }
    
    [HttpPut]
    [Route("UpdateMovie")]
    public ActionResult<Movie> UpdateMovie(MoiveDTO dto)
    {
        var validationResult = _movieValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            return Ok(_movieRepository.UpdataMovie(_mapper.Map<Movie>(dto)));
        }
        return BadRequest(validationResult.ToString());
    }

    [HttpDelete]
    [Route("DeleteMovie")]
    public ActionResult<Movie> DeleteMovie(Movie movie)
    {
        return Ok(_movieRepository.DeleteMovie(movie));
    }

    [HttpGet]
    [Route("CreateDatabase")]
    public ActionResult<string> CreateDB()
    {
        _movieRepository.CreateDB();
        return Ok("Database has been created");
    }
}