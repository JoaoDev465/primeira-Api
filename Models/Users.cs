using MyPosts;
using MyRoles;
using MyUserView;

namespace MyUser;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string  Slug { get; set; }
    public IList <Post> Post {get;set;}
    public IList <Role> Role {get;set;}

  
}