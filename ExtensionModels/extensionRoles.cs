using System.Security.Claims;
using MyRoles;
using MyUser;

namespace MyExtensionRoles;

public static class ExtensionRoles
{
    public static IEnumerable <Claim> GetClaims (this User user)
    {
        var result = new List<Claim> ()
        {
           new ( ClaimTypes.Name,user.Email)
        };
        result.AddRange(user.Role.Select(role => new Claim (ClaimTypes.Role,role.Slug)));

        return result;
    }
}