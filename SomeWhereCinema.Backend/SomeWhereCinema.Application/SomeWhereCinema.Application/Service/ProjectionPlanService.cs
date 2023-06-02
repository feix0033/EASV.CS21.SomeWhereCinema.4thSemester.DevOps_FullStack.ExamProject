using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.IService;
using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.Service;

public class ProjectionPlanService: IProjectionPlanService
{
    private IProjectionPlanRepository _projectionPlanRepository;

    public ProjectionPlanService(IProjectionPlanRepository projectionPlanRepository)
    {
        _projectionPlanRepository = projectionPlanRepository;
    }

    public List<ProjectionPlan> GetAllProjectionPlans()
    {
        return _projectionPlanRepository.FindAll();
    }

    public ProjectionPlan CreatProjectionPlan(ProjectionPlan projectionPlan)
    {
        return _projectionPlanRepository.CreateProjectionPlan(projectionPlan);
    }

    public ProjectionPlan ReadProjectionPlan(ProjectionPlan projectionPlan)
    {
        return _projectionPlanRepository.ReadProjectionPlan(projectionPlan);
    }

    public ProjectionPlan UpdateProjectionPlan(ProjectionPlan projectionPlan)
    {
        return _projectionPlanRepository.UpdateProjectionPlan(projectionPlan);
    }

    public ProjectionPlan DeleteProjectionPlan(ProjectionPlan projectionPlan)
    {
        return _projectionPlanRepository.DeleteProjectionPlan(projectionPlan);
    }

    public List<ProjectionPlan> GetProjectionPlanByMovie(int movieId)
    {
        return _projectionPlanRepository
            .GetProjectionPlanByMovie(
                new ProjectionPlan() 
                {
                    MovieId = movieId
                });
    }
}