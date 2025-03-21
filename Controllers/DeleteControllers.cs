using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDbContext;
using MyPosts;
using MyResultViews;

namespace DeleteItens;

[ApiController]
public class Controller : ControllerBase{

    [HttpDelete("V1/delete/Posts/{id}")]
    public async Task<IActionResult> Delete(
        [FromServices] ApiContext context,
        [FromRoute]int id)
    {

        var posts = await context.Posts.FirstOrDefaultAsync(x=>x.Id== id);
        try{
            if (posts == null)
            return BadRequest(new ResultViewModels<string>("post não encontrado"));

            context.Posts.Remove(posts);
            await context.SaveChangesAsync();

            return Ok(new ResultViewModels<Post>(posts));
        }
        catch
        {
            return BadRequest(new ResultViewModels<Post>("erro : X456 - falha interna no servidor"));
        }
    }
}