namespace Infrastructure.Models;

public class CourseResult
{
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<Course>? Courses { get; set; }
}