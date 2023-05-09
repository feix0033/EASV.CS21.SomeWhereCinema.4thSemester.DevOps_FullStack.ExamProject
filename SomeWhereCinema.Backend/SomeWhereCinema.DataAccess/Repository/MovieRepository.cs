using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.DataAccess.Repository;

public class MovieRepository: IMovieRepository
{
    private readonly MainDbContext _mainDbContext;

    public MovieRepository(MainDbContext mainDbContext)
    {
         _mainDbContext = mainDbContext ?? throw new InvalidDataException("The movie repository should not be null.");
    }

    public List<Movie> FindAll()
    {
        return _mainDbContext.Movies
            .Select(mE => new Movie
            {
                Name = mE.Name,
                ReleaseDate = mE.ReleaseDate,
                PublishTime = mE.PublishTime,
                OffDate = mE.OffDate,
                Price = mE.Price
            }).ToList();
    }
}