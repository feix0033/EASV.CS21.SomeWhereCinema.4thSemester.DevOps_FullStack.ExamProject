using EntityFrameworkCore.Testing.Moq;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess;
using SomeWhereCinema.DataAccess.Entities;
using SomeWhereCinema.DataAccess.Repository;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Infrastructure.Test.SomeWhereCinema.DataAccess.Test;

public class MovieRepositoryTest
{
    private readonly MovieRepository _movieRepository;
    private readonly List<MovieEntity> _movieEntities;

    public MovieRepositoryTest()
    {
        var mockedDbContext = Create.MockedDbContextFor<MovieDbContext>();
        _movieRepository = new MovieRepository(mockedDbContext);
        
        _movieEntities = new List<MovieEntity>()
        {
            new MovieEntity(){Name = "name1", Id = 001,},
            new MovieEntity(){Name = "name2", Id = 002}
        };
        mockedDbContext.Set<MovieEntity>().AddRange(_movieEntities);
        mockedDbContext.SaveChanges();

    }

    [Fact]
    public void MovieRepository_IsMovieRepository()
    {
       
        Assert.IsAssignableFrom<IMovieRepository>(_movieRepository);
    }

    [Fact]
    public void MovieReposotory_WithNullDBContext_ThrowInvalidDataException()
    {
        var invalidDataException = Assert.Throws<InvalidDataException>(() => new MovieRepository(null));
        Assert.Equal("The movie repository should not be null.",invalidDataException.Message);
    }

    [Fact]
    public void FindAll_GetAllMovieEntitiesInDBContext_AsAListOfMovies()
    {
        Assert.Equal(
            _movieEntities
                .Select(mE => new Movie
                {
                    Name = mE.Name, 
                    ReleaseDate = mE.ReleaseDate,
                    PublishTime = mE.PublishTime,
                    OffDate = mE.OffDate,
                    Price = mE.Price
                })
                .ToList(),
            _movieRepository
                .FindAll(),
            new Comparer()
            );
    }

    private class Comparer:IEqualityComparer<Movie>
    {
        public bool Equals(Movie? x, Movie? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Name == y.Name && Nullable.Equals(x.PublishTime, y.PublishTime) && Nullable.Equals(x.ReleaseDate, y.ReleaseDate) && Nullable.Equals(x.OffDate, y.OffDate) && Nullable.Equals(x.Price, y.Price);
        }

        public int GetHashCode(Movie obj)
        {
            return HashCode.Combine(obj.Name, obj.PublishTime, obj.ReleaseDate, obj.OffDate, obj.Price);
        }
    }

}