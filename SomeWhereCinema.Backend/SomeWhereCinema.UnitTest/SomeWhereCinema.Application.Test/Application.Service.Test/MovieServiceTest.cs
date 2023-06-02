using Moq;
using SomeWhereCinema.Application;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Application.Service;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Application.Test.Application.Service.Test;

public class MovieServiceTest
{
    private readonly MovieService _movieService;
    private readonly Mock<IMovieRepository> _mock;
    private List<Movie> _movies;

    public MovieServiceTest()
    {
        _movies = new List<Movie>()
        {
            new Movie(){Name = "name1",ReleaseDate = new DateTime(2023,01,01),PublishTime = new DateTime(2022,12,01),OffDate = new DateTime(2023,02,01)},
            new Movie(){Name = "name2",ReleaseDate = new DateTime(2022,01,01),PublishTime = new DateTime(2021,12,01),OffDate = new DateTime(2022,02,01)},
            new Movie(){Name = "name3",ReleaseDate = new DateTime(2020,01,01),PublishTime = new DateTime(2019,12,01),OffDate = new DateTime(2020,02,01)}
        };
        _mock = new Mock<IMovieRepository>();
        _movieService = new MovieService(_mock.Object);
    }

    [Fact]
    public void MovieService_IsIMovieService()
    {
        Assert.True(_movieService is IMovieService);
    }

    [Fact]
    public void MovieService_WithNullMovieRepository_ThrowsInvalidDataExceptionWithMessage()
    {
        var invalidDataException = 
            Assert.Throws<InvalidDataException>(() => new MovieService(null!));
        
        Assert.Equal("movieRepository can not be null", invalidDataException.Message);
    }

    [Fact]
    public void MovieService_InvokeMovieRepositoryFindAll_ExactlyOnce()
    {
        var movies = _movieService.GetAllMovies();
        _mock.Verify(r => r.FindAll(), Times.Once);
    }

    [Fact]
    public void MovieService_NoFilter_ReturnsListOfAllProducts()
    {
        _mock.Setup(r => r.FindAll()).Returns(_movies);
        Assert.Equal(_movies,_movieService.GetAllMovies());
    }
    
}