using Domain.Core.Models;

namespace Test.Domain.Core.TDD.Core.Move;

public class MovieTest
{
    private readonly Movie _movie;

    public MovieTest()
    {
        _movie = new Movie();
    }

    [Fact]
    public void Movie_CanBeInit()
    {
        Assert.NotNull(_movie);
    }

    [Fact]
    public void Movie_shouldHaveId()
    {
        Assert.NotNull(_movie.id);
    }

    [Fact]
    public void Movie_shouldHaveName()
    {
        Assert.NotNull(_movie.name);
        
    }
}