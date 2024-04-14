

namespace Infrastructure.Models;

public class Pagination
{
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }

    public void UpdateTolatPages()
    {
        TotalPages = (int)Math.Ceiling((double)TotalCount / (double)PageSize);
    }
}