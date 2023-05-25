using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.Service;

public class TheatreService : ITheatreService
{
    private ITheatreRepository _theatreRepository;

    public TheatreService(ITheatreRepository  theatreRepository)
    {
        _theatreRepository = theatreRepository;
    }

    public List<Theatre> GetAllTheatres()
    {
        return _theatreRepository.FindAll();
    }

    public Theatre CreateTheatre(Theatre theatre)
    {
        return _theatreRepository.CreateTheatre(theatre);
    }

    public Theatre? ReadTheatre(Theatre theatre)
    {
        return _theatreRepository.ReadTheatre(theatre);
    }

    public Theatre UpdateTheatre(Theatre theatre)
    {
        return _theatreRepository.UpdateTheatre(theatre);
    }

    public Theatre DeleteTheatre(Theatre theatre)
    {
        return _theatreRepository.DeleteTheatre(theatre);
    }
}