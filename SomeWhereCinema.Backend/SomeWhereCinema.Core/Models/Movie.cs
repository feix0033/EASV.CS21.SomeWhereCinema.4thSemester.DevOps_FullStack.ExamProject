namespace SomeWhereCinema.Core.Models;

public class Movie
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public DateTime? PublishTime { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public DateTime? OffDate { get; set; }
    public double? Price { get; set; }
    public int? Length { get; set; }
}