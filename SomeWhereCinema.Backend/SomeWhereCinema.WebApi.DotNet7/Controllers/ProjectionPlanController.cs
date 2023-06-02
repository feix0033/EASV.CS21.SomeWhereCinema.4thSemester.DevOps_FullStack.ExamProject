using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.WebApi.DotNet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectionPlanController : ControllerBase
    {
        private readonly IProjectionPlanService _projectionPlanService;

        public ProjectionPlanController(IProjectionPlanService projectionPlanService)
        {
            _projectionPlanService = projectionPlanService;
        }

        [HttpGet]
        [Route("GetAllProjectionPlan")]
        public List<ProjectionPlan> GetAll()
        {
            return _projectionPlanService.GetAllProjectionPlans();
        }

        [HttpPost]
        [Route("CreateProjectionPlan")]
        public ProjectionPlan CreateProjectionPlan(ProjectionPlan projectionPlan)
        {
            return _projectionPlanService.CreatProjectionPlan(projectionPlan);
        }

        [HttpPatch]
        [Route("ReadProjectionPlan")]
        public ProjectionPlan ReadProjectionPlan(ProjectionPlan projectionPlan)
        {
            return _projectionPlanService.ReadProjectionPlan(projectionPlan);
        }

        [HttpPatch]
        [Route("ReadProjectionPlanByMovie")]
        public List<ProjectionPlan> GetProjectionPlanByMovie(ProjectionPlan projectionPlan)
        {
            return _projectionPlanService.GetProjectionPlanByMovie(projectionPlan.MovieId);
        }

        [HttpPut]
        [Route("UpdateProjectionPlan")]
        public ProjectionPlan UpdateProjectionPlan(ProjectionPlan projectionPlan)
        {
            return _projectionPlanService.UpdateProjectionPlan(projectionPlan);
        }

        [HttpDelete]
        [Route("DeleteProjectionPlan")]
        public ProjectionPlan DeleteProjectionPlan(ProjectionPlan projectionPlan)
        {
            return _projectionPlanService.DeleteProjectionPlan(projectionPlan);
        }
    }
}
