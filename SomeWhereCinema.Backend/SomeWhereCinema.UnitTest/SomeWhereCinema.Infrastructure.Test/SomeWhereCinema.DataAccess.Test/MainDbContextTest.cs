using EntityFrameworkCore.Testing.Moq;
using Microsoft.EntityFrameworkCore;
using SomeWhereCinema.DataAccess;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Infrastructure.Test.SomeWhereCinema.DataAccess.Test;

public class MainDbContextTest
{
    private readonly MainDbContext _mockedDbContext;

    public MainDbContextTest()
    {
         _mockedDbContext = Create.MockedDbContextFor<MainDbContext>();
    }

    [Fact]
    public void DbContext_whitDbContextOption_IsAvailable()
    {
        Assert.NotNull(_mockedDbContext);
    }

    [Fact]
    public void DbContext_DbSets_MustHaveDbSetWithTypeMovieEntity()
    {
        Assert.True(_mockedDbContext.Movies is DbSet<MovieEntity>);
    }
}