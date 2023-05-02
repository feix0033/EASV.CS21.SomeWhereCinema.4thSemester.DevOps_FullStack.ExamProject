namespace Core.Model.Test;

public class MovieTest
{
    [Fact]
    public void Test_Core_MovieInitialize()
    {
        var movie = new Movie()
        {
            Id = 1,
            Name = "",
            InformationId = 1,
            ReleaseDate = new DateTime().Date,
            OffDate = new DateTime().Date,
            Price = 2.1
        };
        
        Assert.NotNull(movie);
        
    }
}

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? InformationId { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public DateTime? OffDate { get; set; }
    public double? Price { get; set; }
}