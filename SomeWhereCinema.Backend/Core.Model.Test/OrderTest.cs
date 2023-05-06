using Domain.Model;

namespace Core.Model.Test;

public class OrderTest
{
    [Fact]
    public void OrderShouldBeInitialized()
    {
        var order = new Order();
        Assert.NotNull(order);
        Assert.NotNull(order.User);
        Assert.NotNull(order.Movie);
        Assert.NotNull(order.Theater);
        Assert.NotNull(order.SitNumber);
        Assert.NotNull(order.StartTime);
        Assert.NotNull(order.EndTime);
        Assert.NotNull(order.Price);
        
    }
}