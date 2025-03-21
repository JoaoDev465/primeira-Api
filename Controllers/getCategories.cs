using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyCategories;
using MyCategorieView;
using MyDbContext;
using MyResultViews;

namespace GetCategories;

[ApiController]
public class Controller : ControllerBase{
      
      [HttpGet("v1/get/categories")]

    public async Task<IActionResult> GetActionAsync(
        [FromServices] ApiContext context,
        [FromServices] IMemoryCache cache
    )
    {
        try{
            var category = cache.GetOrCreate("categoryCache",entry =>{
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                return GetCategorie(context);
            });
            return Ok (new ResultViewModels<List<Categorie>>(category));
           
        }
        catch{
            return BadRequest(new ResultViewModels<Categorie>("erro : x2%3 - falha interna no servidor"));
        }
       
    }
     private List<Categorie>GetCategorie(ApiContext context)
    {
        return context.Categories.ToList();
    }
}