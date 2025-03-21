using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using MyCategories;
using MyDbContext;
using MyPostFilter;
using MyPosts;
using MyPostsView;
using MyResultViews;

namespace MyGetPosts;


[ApiController]

public class Controller : ControllerBase
{
    [HttpGet("v1/get/posts")]
    public async Task<IActionResult> GetPosts(
        [FromServices] ApiContext context,
        [FromQuery]int pagesize =25,
        [FromQuery]int page=0
    )
    {
     try{
        var posts = context.Posts.
        AsNoTracking().
        Select(x=>new Postmodel(){
            Id = x.Id,
            Title = x.Title,
            Body = x.Body,
            CreatedAt = x.CreatedAt
        })
        .Skip(page * pagesize)
        .Take(page).
        ToListAsync();
        return Ok(new ResultViewModels<dynamic>(new {
            page,
            pagesize,
            posts
        }));
        }
        catch
        {
            return BadRequest(new ResultViewModels<string>("não foi possivel encontrar os posts no database"));
        }
    }
    
  
}