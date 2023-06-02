using Moq;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Core.Test.Domain.IService.Test;

public class IMovieServiceTest
{
    [Fact]
    public void IMovieService_IsAvailable()
    {
        var service = new Mock<IMovieService>().Object;
        Assert.NotNull(service);
    }

    [Fact]
    public void GetMovies_WithNoParameter_ReturnsListOfAllMovie()
    {
        var mock = new Mock<IMovieService>();
        var movieList = new List<Movie>();
        
        mock.Setup(s => s.GetAllMovies())
            .Returns(movieList);

        var movieService = mock.Object;
        Assert.Equal(movieList, movieService.GetAllMovies());
    }
    
    
}