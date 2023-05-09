using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.WebApi.Controllers;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Infrastructure.Test.SomeWhereCinema.WebApi.Test;

public class MovieControllerTest
{
    [Fact]
    public void MovieController_IsOfTypeControllerBase()
    {
        var movieController = new MovieController();
        Assert.IsAssignableFrom<ControllerBase>(movieController);
    }

    [Fact]
    public void MovieController_UseApiControllerAttribute()
    {
        Assert.NotNull(typeof(MovieController)
                .GetTypeInfo()
                .GetCustomAttributes()
                .FirstOrDefault(attr => attr
                        .GetType()
                        .Name
                        .Equals("ApiControllerAttribute")));
    }
}