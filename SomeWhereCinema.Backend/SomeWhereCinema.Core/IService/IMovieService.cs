using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Core.IService;

public interface IMovieService
{
     List<Movie>? GetMovies(); 
}