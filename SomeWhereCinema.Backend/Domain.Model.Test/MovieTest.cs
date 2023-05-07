namespace Domain.Model.Test;

public class MovieTest
{
    private readonly Movie _movie;

    public MovieTest()
    {
        _movie = new Movie()
        {
            Name = "name",
            Actor = new [] {"John","Peter","Mary"},
            Directer = "someone",
            Genre = new Genre(),
            OffDate = new DateTime(),
            Price = 100.00,
            ReleaseDate = new DateTime()
        };
    }

    #region MovieInstance
    [Fact]
    public void Test_Core_Movie_Initialize_NotNull()
    {
        Assert.NotNull(new Movie());
    }

    [Fact]
    public void Test_Core_Movie_Initialize_IsTypeMovie()
    {
        Assert.IsType<Movie>(_movie);
    }
    #endregion

    #region MovieName
    [Fact]
    public void Test_Core_Movie_Name_NotNull()
    {
        Assert.NotNull(_movie.Name);
    }
    
    [Fact]
    public void Test_Core_Movie_Name_IsString()
    {
        Assert.IsType<string>(_movie.Name);
    }
    
    [Fact]
    public void Test_Core_Movie_Name_CanBeAssign()
    {
        Assert.Equal("name",_movie.Name);
    }
    
    [Fact]
    public void Test_Core_Movie_Name_CanBeModify()
    {
        _movie.Name = "Change";
        Assert.Equal("Change",_movie.Name);
    }

    #endregion

    #region MovieActor

    [Fact]
    public void Test_Core_Movie_Actor_NotNull()
    {
        Assert.NotNull(_movie.Actor);
    }

    [Fact]
    public void Test_Core_Movie_Actor_IsList()
    {
        Assert.IsType<string[]>(_movie.Actor);
    }
    

    #endregion
    
    
}
