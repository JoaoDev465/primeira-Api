using MyUser;

namespace MyPostFilter;

public class Postmodel
{
     public int Id { get; set; }

    public string Title {get;set;} = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public int Author { get; set; }

   
}