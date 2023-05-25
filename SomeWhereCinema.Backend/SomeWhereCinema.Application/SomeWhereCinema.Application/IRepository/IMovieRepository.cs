using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.IRepository;

public interface IMovieRepository
{
    List<Movie> FindAll();
    Movie CreateMovie(Movie movie);

    Movie ReadMovie(Movie movie);

    Movie UpdateMovie(Movie movie);

    Movie DeleteMovie(Movie movie);
}