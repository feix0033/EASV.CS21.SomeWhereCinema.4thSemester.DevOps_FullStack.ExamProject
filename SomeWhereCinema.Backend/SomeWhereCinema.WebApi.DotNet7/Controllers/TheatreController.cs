using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.DotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatreController : ControllerBase
    {
        private readonly ITheatreService _theatreService;

        public TheatreController(ITheatreService theatreService)
        {
            _theatreService = theatreService;
        }

        [HttpGet]
        [Route("GetAllTheatre")]
        public List<Theatre> GetAll()
        {
            return _theatreService.GetAllTheatres();
        }

        [HttpPost]
        [Route("CreateTheatre")]
        public Theatre CreateTheatre(Theatre theatre)
        {
            return _theatreService.CreateTheatre(theatre);
        }

        [HttpPatch]
        [Route("ReadTheatre")]
        public Theatre ReadTheatre(Theatre theatre)
        {
            return _theatreService.ReadTheatre(theatre);
        }

        [HttpPut]
        [Route("UpdateTheatre")]
        public Theatre UpdateTheatre(Theatre theatre)
        {
            return _theatreService.UpdateTheatre(theatre);
        }

        [HttpDelete]
        [Route("DeleteTheatre")]
        public Theatre DeleteTheatre(Theatre theatre)
        {
            return _theatreService.DeleteTheatre(theatre);
        }
    }
}
