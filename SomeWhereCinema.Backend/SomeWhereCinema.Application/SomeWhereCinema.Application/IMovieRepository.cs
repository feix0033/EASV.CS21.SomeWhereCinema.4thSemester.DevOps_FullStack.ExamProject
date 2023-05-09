using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application;

public interface IMovieRepository
{
    List<Movie> FindAll();
}