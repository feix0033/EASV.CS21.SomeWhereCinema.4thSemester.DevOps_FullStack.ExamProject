using SomeWhereCinema.Application.IRepository;
using SomeWhereCinema.Core.Models;
using SomeWhereCinema.DataAccess.Converter;
using SomeWhereCinema.DataAccess.DbContext;
using SomeWhereCinema.DataAccess.Entities;

namespace SomeWhereCinema.DataAccess.Repository;

public class ProjectionPlanRepository : IProjectionPlanRepository
{
    private DBContext _dbContext;

    public ProjectionPlanRepository(DBContext projectionPlanDbContext)
    {
         _dbContext = projectionPlanDbContext;
    }

    private void createDb()
    {
        _dbContext.Database.EnsureDeleted();
        _dbContext.Database.EnsureCreated();
    }


    public List<ProjectionPlan> FindAll()
    {
        var projectionPlans = new List<ProjectionPlan>();
        var projectionPlanEntities = _dbContext.ProjectionPlanTable.ToList();
        foreach (ProjectionPlanEntity projectionPlanEntity in projectionPlanEntities)
        {
            projectionPlans.Add(ProjectionPlanConverter.Converter(projectionPlanEntity));
        }

        return projectionPlans;
    }

    public ProjectionPlan CreateProjectionPlan(ProjectionPlan projectionPlan)
    {
        var projectionPlanEntity = 
            _dbContext.ProjectionPlanTable
                .Add(ProjectionPlanConverter.Converter(projectionPlan)).Entity;
        _dbContext.SaveChanges();
        return ProjectionPlanConverter.Converter(projectionPlanEntity);
    }

    public ProjectionPlan ReadProjectionPlan(ProjectionPlan projectionPlan)
    {
        var projectionPlanEntity = _dbContext.ProjectionPlanTable
            .FirstOrDefault(p => p.Id == projectionPlan.Id);
        if (projectionPlanEntity != null)
        {
            return ProjectionPlanConverter.Converter(projectionPlanEntity);
        }

        return new ProjectionPlan() { Id = 0 };
    }

    public ProjectionPlan UpdateProjectionPlan(ProjectionPlan projectionPlan)
    {
        var projectionPlanEntity = 
                _dbContext.ProjectionPlanTable
                    .Update(ProjectionPlanConverter.Converter(projectionPlan)).Entity;
            _dbContext.SaveChanges();
        return ProjectionPlanConverter.Converter(projectionPlanEntity);
    }

    public ProjectionPlan DeleteProjectionPlan(ProjectionPlan projectionPlan)
    {
        if (ReadProjectionPlan(projectionPlan).Id != 0)
        {
            var projectionPlanEntity = 
                _dbContext.ProjectionPlanTable
                    .Remove(ProjectionPlanConverter.Converter(projectionPlan)).Entity;
            _dbContext.SaveChanges();
            return ProjectionPlanConverter.Converter(projectionPlanEntity);
        }

        return new ProjectionPlan() { Id = 0 };
    }

    public List<ProjectionPlan> GetProjectionPlanByMovie(ProjectionPlan projectionPlan)
    {
        var projectionPlans = new List<ProjectionPlan>();
        var projectionPlanEntities = _dbContext.ProjectionPlanTable
            .Where( p => p.MovieId ==  projectionPlan.MovieId);
        foreach (var projectionPlanEntity in projectionPlanEntities)
        {
            projectionPlans.Add(ProjectionPlanConverter.Converter(projectionPlanEntity));
        }

        return projectionPlans;
    }
}