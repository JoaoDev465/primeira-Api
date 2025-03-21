using MyUser;

namespace MyRoles;

public class Role
{
    public int Id { get; set; }
    public string NameRole { get; set; }

    public string  Slug{ get; set; }

    public IList<User> User {get;set;}

}