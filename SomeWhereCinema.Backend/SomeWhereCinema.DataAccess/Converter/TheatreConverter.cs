using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess.Converter;

public class TheatreConverter
{
    public static Theatre Converter(TheatreEntity theatreEntity)
    {
        return new Theatre
        {
            Id = theatreEntity.Id,
            SitNumber = theatreEntity.SitNumber
        };
    }

    public static TheatreEntity Converter(Theatre theatre)
    {
        return new TheatreEntity
        {
            Id = theatre.Id,
            SitNumber = theatre.SitNumber
        };
    }
}