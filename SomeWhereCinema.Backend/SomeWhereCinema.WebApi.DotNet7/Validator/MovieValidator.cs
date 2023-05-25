using FluentValidation;
using SomeWhereCinema.WebApi.DotNet7.DTOS;

namespace SomeWhereCinema.WebApi.DotNet7.Validator;

public class MovieValidator: AbstractValidator<MovieDto>
{
    public MovieValidator()
    {
        RuleFor(m => m.Price).GreaterThan(0);
        RuleFor(m => m.Name).NotEmpty();
    }
}