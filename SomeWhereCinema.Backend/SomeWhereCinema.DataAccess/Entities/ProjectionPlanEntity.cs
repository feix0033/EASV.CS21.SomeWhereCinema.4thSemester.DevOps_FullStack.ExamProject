namespace SomeWhereCinema.DataAccess.Entities;

public class ProjectionPlanEntity
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int TheatreId { get; set; }
    public DateTime StartTime { get; set; }
}