using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.Service;

public class MovieService : IMovieService
{
    private IMovieRepository _movieRepository;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository ?? throw new InvalidDataException("movieRepository can not be null");
    }

    public List<Movie> GetAllMovies()
    {
        return _movieRepository.FindAll();
    }

    public Movie CreateMovie(Movie movie)
    {
        return _movieRepository.CreateMovie(movie);
    }

    public Movie ReadMovie(Movie movie)
    {
        return _movieRepository.ReadMovie(movie);
    }

    public Movie UpdateMovie(Movie movie)
    {
        return _movieRepository.UpdateMovie(movie);
    }

    public Movie DeleteMovie(Movie movie)
    {
        return _movieRepository.DeleteMovie(movie);
    }
}
