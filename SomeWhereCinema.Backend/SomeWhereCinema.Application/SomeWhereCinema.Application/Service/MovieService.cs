using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.Service;

public class MovieService : IMovieService
{
    private IMovieRepository _movieRepostitory;

    public MovieService(IMovieRepository movieRepository)
    {
        _movieRepostitory = movieRepository ?? throw new InvalidDataException("movieRepository can not be null");
    }

    public List<Movie> GetMovies()
    {
        return _movieRepostitory.FindAll();
    }

    public Movie CreateMovie(Movie movie)
    {
        return _movieRepostitory.CreateMovie(movie);
    }

    public Movie? ReadMovie(Movie movie)
    {
        return _movieRepostitory.ReadMovie(movie);
    }

    public Movie UpdateMovie(Movie movie)
    {
        return _movieRepostitory.UpdataMovie(movie);
    }

    public Movie DeleteMovie(Movie movie)
    {
        return _movieRepostitory.DeleteMovie(movie);
    }

    public void ReInitDb()
    {
        _movieRepostitory.CreateDb();
    }
}
