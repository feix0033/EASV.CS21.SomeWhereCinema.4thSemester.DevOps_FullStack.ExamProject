using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.IRepository;

public interface IMovieRepository
{
    List<Movie> FindAll();
}