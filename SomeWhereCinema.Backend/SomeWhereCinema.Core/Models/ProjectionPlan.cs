
namespace SomeWhereCinema.Core.Models;

public class ProjectionPlan
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int TheatreId { get; set; }
    public DateTime StartTime { get; set; }
}