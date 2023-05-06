using Domain.Model;

namespace Core.Model.Test;

public class MovieTest
{
    [Fact]
    public void Test_Core_MovieInitialize()
    {
        var movie = new Movie();

        Assert.NotNull(movie);
         
    }
}