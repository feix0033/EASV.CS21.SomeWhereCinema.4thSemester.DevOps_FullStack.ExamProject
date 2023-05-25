using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Core.IService;

public interface ITheatreService
{
    List<Theatre> GetAllTheatres();
    Theatre CreateTheatre(Theatre theatre);
    Theatre ReadTheatre(Theatre theatre);
    Theatre UpdateTheatre(Theatre theatre);
    Theatre DeleteTheatre(Theatre theatre);
}