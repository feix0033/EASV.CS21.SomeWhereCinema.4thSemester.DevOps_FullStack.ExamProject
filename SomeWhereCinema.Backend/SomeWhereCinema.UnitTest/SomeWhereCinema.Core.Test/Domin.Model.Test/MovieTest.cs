using SomeWhereCinema.Core;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.UnitTest;

public class MovieTest
{
    private readonly Movie _movie;

    public MovieTest()
    {
        _movie = new Movie()
        {
            Name = "name",
            PublishTime = new DateTime(2023,5,7),
            ReleaseDate = new DateTime(2023,5,7),
            OffDate = new DateTime(2023,6,7),
            Price = 86.0
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

    #region Name
    
    [Fact]
    public void Test_Core_Movie_Name_IsString()
    {
        Assert.IsType<string>(_movie.Name);
    }

    [Fact]
    public void Test_Core_Movie_Name_CanBeNull()
    {
        _movie.Name = null;
        Assert.Null(_movie.Name);
    }
    
    [Fact]
    public void Test_Core_Movie_Name_CanBeAssign()
    {
        _movie.Name = "name";
        Assert.Equal("name",_movie.Name);
    }
    
    [Fact]
    public void Test_Core_Movie_Name_CanBeModify()
    {
        _movie.Name = "Change";
        Assert.Equal("Change",_movie.Name);
    }

    #endregion

    #region ReleaseDate

    [Fact]
    public void Test_Core_Movie_ReleaseDate_CanBeNull()
    {
        _movie.ReleaseDate = null;
        Assert.Null(_movie.ReleaseDate);
    }

    [Fact]
    public void Test_Core_Movie_ReleaseDate_IsDateTime()
    {
        Assert.IsType<DateTime>(_movie.ReleaseDate);
    }

    [Fact]
    public void Test_Core_Moive_ReleaseDate_CanStoreValue()
    {
        Assert.True(_movie.ReleaseDate.HasValue);
    }

    [Fact]
    public void Test_Core_Movie_ReleaseDate_CanBeModify()
    {
        _movie.ReleaseDate = new DateTime(2022,1,1);
        Assert.Equal(new DateTime(2022,1,1),_movie.ReleaseDate.Value);
    }
    
    #endregion
    
    #region PublishTime

    [Fact]
    public void Test_Core_Movie_PublishTime_CanBeNull()
    {
        _movie.PublishTime = null;
        Assert.Null(_movie.PublishTime);
    }

    [Fact]
    public void Test_Core_Movie_PublishTime_IsDateTime()
    {
        Assert.IsType<DateTime>(_movie.PublishTime);
    }

    [Fact]
    public void Test_Core_Movie_PublishTime_CanStoreDate()
    {
        Assert.True(_movie.PublishTime.HasValue);
    }

    [Fact]
    public void Test_Core_Movie_PublishTime_CanBeModify()
    {
        _movie.PublishTime = new DateTime(2022,1,1);
        Assert.Equal(new DateTime(2022,1,1),_movie.PublishTime.Value);
    }
    
    #endregion

    #region OffDate
    
    [Fact]
    public void Test_Core_Movie_OffDate_CanBeNull()
    {
        _movie.OffDate = null;
        Assert.Null(_movie.OffDate);
    }

    [Fact]
    public void Test_Core_Movie_OffDate_IsDateTime()
    {
        Assert.IsType<DateTime>(_movie.OffDate);
    }

    [Fact]
    public void Test_Core_Movie_OffDate_CanStoreDate()
    {
        Assert.True(_movie.OffDate.HasValue);
    }
    
    [Fact]
    public void Test_Core_Movie_OffDate_CanBeModify()
    {
        _movie.OffDate = new DateTime(2022,1,1);
        Assert.Equal(new DateTime(2022,1,1) , _movie.OffDate.Value);
    }
    
    #endregion

    #region Price

    [Fact]
    public void Test_Core_Movie_Price_CanBeNull()
    {
        _movie.Price = null;
        Assert.Null(_movie.Price);
    }

    [Fact]
    public void Test_Core_Movie_Price_IsDouble()
    {
        Assert.IsType<double>(_movie.Price);
    }

    [Fact]
    public void Test_Core_Movie_Price_CanStoreValue()
    {
        Assert.Equal(86.0,_movie.Price);
    }

    [Fact]
    public void Test_Core_Movie_Price_CanBeModify()
    {
        _movie.Price = 88.7;
        Assert.Equal(88.7,_movie.Price);
    }

    #endregion
    
}
