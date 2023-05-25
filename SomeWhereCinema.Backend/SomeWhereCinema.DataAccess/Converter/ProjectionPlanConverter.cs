using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess.Converter;

public class ProjectionPlanConverter
{
    public static ProjectionPlan Converter(ProjectionPlanEntity projectionPlanEntity)
    {
        return new ProjectionPlan
        {
            Id = projectionPlanEntity.Id,
            MovieId = projectionPlanEntity.MovieId,
            TheatreId = projectionPlanEntity.TheatreId,
            StartTime = projectionPlanEntity.StartTime
        };
    }

    public static ProjectionPlanEntity Converter(ProjectionPlan projectionPlan)
    {
        return new ProjectionPlanEntity
        {
            Id = projectionPlan.Id,
            MovieId = projectionPlan.MovieId,
            TheatreId = projectionPlan.TheatreId,
            StartTime = projectionPlan.StartTime
        };
    }
}