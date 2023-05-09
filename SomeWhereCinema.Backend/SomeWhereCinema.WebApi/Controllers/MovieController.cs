using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController:ControllerBase
{ 
    [HttpGet]
    public ActionResult<List<Movie>> GetAll()
    {
        return null;
    }
}