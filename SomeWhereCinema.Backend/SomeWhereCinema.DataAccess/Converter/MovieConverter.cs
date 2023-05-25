using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess.Converter;

public class MovieConverter
{
    public static Movie Converter(MovieEntity movieEntity)
    {
        return new Movie
        {
            Id = movieEntity.Id,
            Name = movieEntity.Name,
            PublishTime = movieEntity.PublishTime,
            ReleaseDate = movieEntity.ReleaseDate,
            OffDate = movieEntity.OffDate,
            Length = movieEntity.Length,
            Price = movieEntity.Price
        };
    }

    public static MovieEntity Converter(Movie movie)
    {
        return new MovieEntity
        {
            Id = movie.Id,
            Name = movie.Name,
            PublishTime = movie.PublishTime,
            ReleaseDate = movie.ReleaseDate,
            OffDate = movie.OffDate,
            Length = movie.Length,
            Price = movie.Price
        };
    }
}