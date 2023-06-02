using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Core.IService;

public interface IProjectionPlanService
{
    List<ProjectionPlan> GetAllProjectionPlans();
    ProjectionPlan CreatProjectionPlan(ProjectionPlan projectionPlan);
    ProjectionPlan ReadProjectionPlan(ProjectionPlan projectionPlan);
    ProjectionPlan UpdateProjectionPlan(ProjectionPlan projectionPlan);
    ProjectionPlan DeleteProjectionPlan(ProjectionPlan projectionPlan);
    List<ProjectionPlan> GetProjectionPlanByMovie(int movieId);
}