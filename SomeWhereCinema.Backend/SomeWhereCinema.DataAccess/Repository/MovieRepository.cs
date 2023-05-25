using Microsoft.EntityFrameworkCore;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Converter;
using SomeWhereCinema.DataAccess.DbContext;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess.Repository;

public class MovieRepository : IMovieRepository
{
    private readonly DBContext _dbContext;

    public MovieRepository(DBContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public void CreateDb()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }

    public List<Movie> FindAll()
    {
        var movies = new List<Movie>();
        var movieEntities = _dbContext.MovieTable.ToList();
        foreach (var movieEntity in movieEntities)
        {
            movies.Add(MovieConverter.Converter(movieEntity));
        }

        return movies;
    }

    public Movie CreateMovie(Movie movie)
    {
        var movieEntity = _dbContext.MovieTable.Add(MovieConverter.Converter(movie)).Entity;
        _dbContext.SaveChanges();
        return MovieConverter.Converter(movieEntity);
    }

    public Movie ReadMovie(Movie movie)
    {
        var movieEntity = new MovieEntity();

        if (movie.Id == 0)
        {
            movieEntity = _dbContext.MovieTable
                .FirstOrDefault(m => m.Name == movie.Name);
        }
        
        movieEntity = _dbContext.MovieTable
            .FirstOrDefault(m => m.Id == movie.Id);
        
        if (movieEntity != null)
        {
            return MovieConverter.Converter(movieEntity);
        }

        return new Movie() { Id = 0 };
    }

    public Movie UpdateMovie(Movie movie)
    {
        var movieEntity = _dbContext.MovieTable.Update(MovieConverter.Converter(movie)).Entity;
        _dbContext.SaveChanges();
        return MovieConverter.Converter(movieEntity);
    }

    public Movie DeleteMovie(Movie movie)
    {
        try
        {
            var removedEntity = _dbContext.MovieTable.Remove(MovieConverter.Converter(movie)).Entity;
            _dbContext.SaveChanges();
            return MovieConverter.Converter(removedEntity);
        }
        catch (DbUpdateConcurrencyException e)
        {
            Console.WriteLine(e.Message);
            throw new DbUpdateConcurrencyException();
        }
    }
}