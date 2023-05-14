using Microsoft.Extensions.DependencyInjection;
using SomeWhereCinema.Application.Service;
using SomeWhereCinema.Core.IService;

namespace SomeWhereCinema.Application.DependencyResolver;

public class DependencyResolverService
{
    public static void RegisterApplicationLayer(IServiceCollection service)
    {
        service.AddScoped<IMovieService, MovieService>();
    }
}