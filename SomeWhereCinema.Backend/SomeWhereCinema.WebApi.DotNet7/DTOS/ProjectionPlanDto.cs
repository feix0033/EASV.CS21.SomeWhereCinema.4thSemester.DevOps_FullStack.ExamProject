namespace SomeWhereCinema.WebApi.DotNet7.DTOS;

public class ProjectionPlanDto
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int TheatreId { get; set; }
    public DateTime StartTime { get; set; }
}