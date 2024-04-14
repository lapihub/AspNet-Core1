namespace Infrastructure.Models;

public class CourseRegistrationForm
{
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string OriginalPrice { get; set; } = null!;
    public int Hours { get; set; }
    public bool IsDigital { get; set; }
    public string? ImageUrl { get; set; }
    public string Category { get; set; } = null!;
}