namespace Domain.Model;

public class Movie
{
    public string? Name { get; set; }
    public DateTime? PublishTime { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public DateTime? OffDate { get; set; }
    public double? Price { get; set; }
}