using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using System.Linq;

namespace MyExtenssionViews;

public static class Extensions
{
    public static List<string> GetErrors (this ModelStateDictionary modelState)
    {
        var Result = new List<string> ();
        
        foreach (var item in modelState.Values)
        {
            Result.AddRange(item.Errors.Select (Values => Values.ErrorMessage));
        }
        return Result;
    }

}