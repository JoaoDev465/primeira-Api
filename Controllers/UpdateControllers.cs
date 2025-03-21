using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDbContext;
using MyPosts;
using MyPostsView;
using MyResultViews;

namespace MyUpdateController;

[ApiController]
public class Controller: ControllerBase
{
    [HttpPut("v1/update/Posts/{id}")]
    public async Task <IActionResult> PutControllers(
        [FromServices] ApiContext context,
        [FromRoute] int id,
        [FromBody] PostView view
    )
    {
        var posts = await context.Posts.FirstOrDefaultAsync(x=>x.Id == id);

        try
        {
            if(posts == null)
            return   BadRequest (new ResultViewModels<string>("o post não foi encontrado"));

            posts.Title = view.Title;
            posts.Body = view.Body;

            context.Posts.Update(posts);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModels<Post>(posts));
        }
        catch
        {
            return BadRequest(new ResultViewModels<Post>("erro : X3$5 - falha interna no servidor"));
        }
    }
}