using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NuGet.Protocol.Plugins;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.WebApi.Controllers;

namespace SomeWhereCinema.UnitTest.SomeWhereCinema.Infrastructure.Test.SomeWhereCinema.WebApi.Test;

public class MovieControllerTest
{
    [Fact]
    public void MovieController_HasMovieService_IsTypeOfControllerBase()
    {
        Assert.IsAssignableFrom<ControllerBase>(
            new MovieController(new Mock<IMovieService>().Object)
            );
    }
    
    [Fact]
    public void MovieController_HasMovieService_NullThrowException()
    {
        Assert.Equal(
            "movieService can not be null.",
            Assert.Throws<InvalidDataException>(
                    () => new MovieController(null)
                    )
                .Message
            );
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

    [Fact]
    public void MovieController_UseRouteAttribute_WithParamApiControllerNameRoute()
    {
        var attribute = typeof(MovieController)
            .GetTypeInfo()
            .GetCustomAttributes()
            .FirstOrDefault(attr => attr
                .GetType()
                .Name
                .Equals("RouteAttribute"));
        var routeAttr = attribute as RouteAttribute;
        
        Assert.NotNull(attribute);
        Assert.Equal("api/[controller]", routeAttr?.Template);
    }

    [Fact]
    public void MovieController_HasGetAllMethod()
    {
        Assert.NotNull(
            typeof(MovieController)
            .GetMethods()
            .FirstOrDefault(method => "GetAll".Equals(method.Name))
        );
    }

    [Fact]
    public void MovieController_HasGetAllMethod_IsPublic()
    {
        Assert.True(
            typeof(MovieController)
                .GetMethods()
                .FirstOrDefault(method => "GetAll".Equals(method.Name))!
                .IsPublic
        );
    }
    
    [Fact]
    public void MovieController_HasGetAllMethod_ReturnsListOfProductsInActionResult()
    {
        Assert.Equal(
            typeof(ActionResult<List<Movie>>)
                .FullName,
            typeof(MovieController)
                .GetMethods()
                .FirstOrDefault(method => "GetAll".Equals(method.Name))!
                .ReturnType
                .FullName
        );
    }
    [Fact]
    public void MovieController_GetAllMethod_HasGetHttpAttribute()
    {
        
    }
}