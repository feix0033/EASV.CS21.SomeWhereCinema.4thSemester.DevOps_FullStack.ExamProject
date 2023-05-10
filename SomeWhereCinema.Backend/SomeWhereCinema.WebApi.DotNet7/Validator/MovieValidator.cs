using FluentValidation;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.WebApi.DotNet7.Controllers;

namespace SomeWhereCinema.WebApi.DotNet7;

public class MovieValidator: AbstractValidator<MoiveDTO>
{
    public MovieValidator()
    {
        RuleFor(m => m.Price).GreaterThan(0);
        RuleFor(m => m.Name).NotEmpty();
    }
}