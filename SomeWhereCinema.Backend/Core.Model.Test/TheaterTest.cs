namespace Core.Model.Test;

public class TheaterTest
{
    [Fact]
    public void TheaterCanBeInitialized()
    {
        var theater = new Theater(){};
        Assert.NotNull(theater);
        Assert.NotNull(theater.Id);
        Assert.NotNull(theater.SitAmount);
    }
}

public class Theater
{
    public int Id { get; set; }
    public int? SitAmount { get; set; }
    public Array? SitAvailableMark { get; set; }
}
