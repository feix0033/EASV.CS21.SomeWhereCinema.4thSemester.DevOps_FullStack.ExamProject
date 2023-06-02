namespace SomeWhereCinema.Core.Models;

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ProjectionPlan { get; set; }
    public int SitNumber { get; set; }
}