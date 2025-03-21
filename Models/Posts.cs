
using MyCategories;
using Mytags;
using MyUser;

namespace MyPosts;

public class Post
{
    public int Id { get; set; }

    public string Title {get;set;} = string.Empty;
    public string? Image { get; set; }
    public string? Summary { get; set; } 
    public string Body { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public int Authorid { get; set; }
    public User Author { get; set; }

    public int? CategorieId { get; set; }
    public Categorie? Categories{ get; set; }
    
}