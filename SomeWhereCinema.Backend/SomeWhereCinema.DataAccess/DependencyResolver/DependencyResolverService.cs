using Microsoft.Extensions.DependencyInjection;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.DataAccess.Repository;

namespace SomeWhereCinema.DataAccess.DependencyResolver;

public class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection service)
    {
        service.AddScoped<IMovieRepository, MovieRepository >();
    }
}