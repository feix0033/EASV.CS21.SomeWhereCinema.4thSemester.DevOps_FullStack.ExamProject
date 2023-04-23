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
    public void Movie_shouldHaveIdMustBeInt()
    {
        Assert.True(_movie.id is int);
    }

    [Fact]
    public void Movie_shouldHaveNameMustBeString()
    {
        Assert.True(_movie.name is string);
        
    }
}