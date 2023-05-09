using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepostitory;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepostitory = movieRepository ?? throw new InvalidDataException("movieRepository can not be null");
    }

    public List<Movie> GetMovies()
    {
        return _movieRepostitory.FindAll();
    }
}
