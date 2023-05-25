using SomeWhereCinema.Core.Models;

namespace SomeWhereCinema.Application.IRepository;

public interface IProjectionPlanRepository
{
    List<ProjectionPlan> FindAll();
    ProjectionPlan CreateProjectionPlan(ProjectionPlan projectionPlan);
    ProjectionPlan ReadProjectionPlan(ProjectionPlan projectionPlan);
    ProjectionPlan UpdateProjectionPlan(ProjectionPlan projectionPlan);
    ProjectionPlan DeleteProjectionPlan(ProjectionPlan projectionPlan);
    List<ProjectionPlan> GetProjectionPlanByMovie(ProjectionPlan projectionPlan);
}