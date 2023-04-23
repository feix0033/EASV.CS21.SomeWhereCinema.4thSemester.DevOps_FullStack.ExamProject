using Domain.Core.Models;

namespace Test.Domain.Core.TDD.Core.Move;

public class MovieTest
{
    [Fact]
    public void Movie_CanBeInit()
    {
        var movie = new Movie();
        Assert.NotNull(movie);
    }

    public void Movie_shouldHaveId()
    {
        var movie = new Movie();
        Assert.NotNull(movie.id);
    }
}