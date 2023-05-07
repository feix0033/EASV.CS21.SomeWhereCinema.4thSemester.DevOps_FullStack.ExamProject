using Domain.IService;
using Moq;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Core.Test.Domain.IService.Test;

public class IMovieServiceTest
{
    [Fact]
    public void IMovieService_IsAvailable()
    {
        IMovieService service = new Mock<IMovieService>().Object;
        Assert.NotNull(service);
        
    }
}