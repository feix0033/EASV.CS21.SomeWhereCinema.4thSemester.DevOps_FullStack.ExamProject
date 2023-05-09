using EntityFrameworkCore.Testing.Moq;
using SomeWhereCinema.DataAccess;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Infrastructure.Test.SomeWhereCinema.DataAccess.Test;

public class MainDbContextTest
{
    [Fact]
    public void DbContext_whitDbContextOption_IsAvailable()
    {
        var mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
        Assert.NotNull(mockedDbContext);
    }
}