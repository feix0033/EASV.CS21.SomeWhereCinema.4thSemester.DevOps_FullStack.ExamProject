namespace Domain.Model;

public class Order
{
    public User? User { get; set; }
    public Movie? Movie { get; set; }
    public Theater? Theater { get; set; }
    public int? SitNumber { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public int? Price { get; set; }
}