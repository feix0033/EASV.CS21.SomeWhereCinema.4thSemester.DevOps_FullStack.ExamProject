namespace Domain.Model;

public class Movie
{
    public string? Name { get; set; }
    public Genre? Genre { get; set; }
    public string? Directer { get; set; }
    public List<string>? Actor { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public DateTime? OffDate { get; set; }
    public double? Price { get; set; }
}