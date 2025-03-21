using MyPosts;

namespace MyCategorieView;

public class CategorieView
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int? PostId { get; set; }

}