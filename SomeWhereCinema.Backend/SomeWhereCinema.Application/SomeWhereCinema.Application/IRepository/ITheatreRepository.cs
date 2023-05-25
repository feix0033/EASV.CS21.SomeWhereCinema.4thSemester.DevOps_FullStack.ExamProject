using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.IRepository;

public interface ITheatreRepository
{
    List<Theatre> FindAll();
    Theatre CreateTheatre(Theatre theatre);
    Theatre? ReadTheatre(Theatre theatre);
    Theatre UpdateTheatre(Theatre theatre);
    Theatre DeleteTheatre(Theatre theatre);
}