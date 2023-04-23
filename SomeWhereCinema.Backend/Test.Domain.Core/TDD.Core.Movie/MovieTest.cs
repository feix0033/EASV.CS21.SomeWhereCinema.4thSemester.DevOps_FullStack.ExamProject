namespace Test.Domain.Core.TDD.Core.Movie;

public class MovieTest
{
    private readonly global::Domain.Core.Models.Movie _movie;

    public MovieTest()
    {
        _movie = new global::Domain.Core.Models.Movie()
        {
            id = 1,
            name = "test movie"
        };
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
        Assert.NotNull(_movie.name);
        Assert.True(_movie.name is string);
        
    }
}