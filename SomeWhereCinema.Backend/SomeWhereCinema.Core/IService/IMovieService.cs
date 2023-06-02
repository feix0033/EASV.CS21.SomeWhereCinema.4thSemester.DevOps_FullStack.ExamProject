using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Core.IService;

public interface IMovieService
{
     List<Movie>? GetAllMovies();
     Movie CreateMovie(Movie movie);
     Movie ReadMovie(Movie movie);
     Movie UpdateMovie(Movie movie);
     Movie DeleteMovie(Movie movie);
}