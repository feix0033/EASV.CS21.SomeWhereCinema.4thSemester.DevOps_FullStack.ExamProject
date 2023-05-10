using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.DataAccess.Repository;

public class MovieRepository: IMovieRepository
{
    private MovieDbContext _movieDbContext;

    public MovieRepository(MovieDbContext movieDbContext)
    {
         _movieDbContext = movieDbContext ?? throw new InvalidDataException("The movieEntity repository should not be null.");
    }
    public List<Movie> FindAll()
    {
        return _movieDbContext.MovieTable.ToList();
    }

    public Movie CreateMovie(Movie movie)
    {
        _movieDbContext.MovieTable.Add(movie);
        _movieDbContext.SaveChanges();
        return movie;
    }

    public Movie ReadMovie(Movie movie)
    {
        return _movieDbContext.MovieTable.Find(movie.Id)?? throw new InvalidDataException("we don't have this movie");
    }

    public Movie UpdataMovie(Movie movie)
    {
        _movieDbContext.MovieTable.Update(movie);
        _movieDbContext.SaveChanges();
        return movie;
    }

    public Movie DeleteMovie(Movie movie)
    {
        _movieDbContext.MovieTable.Remove(movie);
        _movieDbContext.SaveChanges();
        return movie;
    }

    public void CreateDB()
    {
        _movieDbContext.Database.EnsureDeleted();
        _movieDbContext.Database.EnsureCreated();
    }
}