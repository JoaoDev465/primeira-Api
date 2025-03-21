using MyPosts;

namespace MyCategories ;

public class Categorie
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description{ get; set; } 
    public DateTime CreatedAt {get;set;} = DateTime.Now;

    public  int? PostId { get; set; }
    public List<Post>? Post {get;set;}
}