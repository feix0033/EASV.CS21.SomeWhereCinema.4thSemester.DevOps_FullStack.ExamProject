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
}