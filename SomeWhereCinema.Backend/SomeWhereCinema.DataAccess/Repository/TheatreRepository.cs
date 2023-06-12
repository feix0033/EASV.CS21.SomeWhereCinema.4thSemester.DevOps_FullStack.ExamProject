using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Converter;
using SomeWhereCinema.DataAccess.DbContext;

namespace SomeWhereCinema.DataAccess.Repository;

public class TheatreRepository : ITheatreRepository
{
    private readonly DBContext _dbContext;

    public TheatreRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
        // _dbContext.Database.EnsureDeleted();
        // _dbContext.Database.EnsureCreated();
    }
    
    private void CreateDb()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    public List<Theatre> FindAll()
    {
        var theatresList = new List<Theatre>();
        var theatreEntitiesList = _dbContext.TheatreTable.ToList();
        foreach (var theatreEntity in theatreEntitiesList)
            theatresList.Add(TheatreConverter.Converter(theatreEntity));

        return theatresList;
    }

    public Theatre CreateTheatre(Theatre theatre)
    {
        var theatreEntity = _dbContext.TheatreTable.Add(TheatreConverter.Converter(theatre)).Entity;
        _dbContext.SaveChanges();
        return TheatreConverter.Converter(theatreEntity);
    }

    public Theatre ReadTheatre(Theatre theatre)
    {
        var theatreEntity = _dbContext.TheatreTable.FirstOrDefault(t => t.Id == theatre.Id);
        if (theatreEntity != null) 
            return TheatreConverter.Converter(theatreEntity);
        return new Theatre(){Id = 0};
    }

    public Theatre UpdateTheatre(Theatre theatre)
    {
        var theatreEntity = _dbContext.TheatreTable.Update(TheatreConverter.Converter(theatre)).Entity;
        _dbContext.SaveChanges();
        return TheatreConverter.Converter(theatreEntity);

    }

    public Theatre DeleteTheatre(Theatre theatre)
    {
        var theatreEntity = _dbContext.TheatreTable.Remove(TheatreConverter.Converter(theatre)).Entity;
        _dbContext.SaveChanges();
        return TheatreConverter.Converter(theatreEntity);
    }

    
}