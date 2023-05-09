using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.Service;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _movieRepostitory;

    public MovieService(IMovieRepository movieRepository)
    {
        if (movieRepository == null)
        {
            throw new InvalidDataException("movieRepository can not be null");
        }

        _movieRepostitory = movieRepository;
    }

    public List<Movie> GetMovies()
    {
        return _movieRepostitory.FindAll();
    }
}
