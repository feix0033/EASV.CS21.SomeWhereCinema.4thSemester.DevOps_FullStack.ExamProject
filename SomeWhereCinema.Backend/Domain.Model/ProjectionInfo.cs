namespace Domain.Model;

public class ProjectionInfo
{
    public Movie Movie { get; set; }
    public Theater Theater { get; set; }
    public DateTime ShowTime { get; set; }
    public DateTime EndTime { get; set; }
}