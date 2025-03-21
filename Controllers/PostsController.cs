using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using MyCategories;
using MyCategorieView;
using MyDbContext;
using MyExtenssionViews;
using MyPosts;
using MyPostsView;
using MyResultViews;
using Mytags;
using MyTagView;
using MyUser;
using MyUserView;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Pkcs;

namespace MypostController;

    [ApiController]
public class PostController:ControllerBase
{
    [HttpPost("v1/Posts")]
    public async Task<IActionResult> PostItens(
        [FromServices] ApiContext context,
        [FromBody] PostView view
    )
    {
        if(!ModelState.IsValid){
            return BadRequest(new ResultViewModels<PostView>(ModelState.GetErrors()));
        }

        var posts = new Post(){
            Title = view.Title,
            Body = view.Body,
            Slug = view.Slug,
            Authorid = 1
        };

        try
        {
            await context.Posts.AddAsync(posts);
            await context.SaveChangesAsync();
            return Ok(new ResultViewModels<PostView>(view));
        }
        catch(DbException ex){
            return BadRequest(ex.Message);
        }
        catch (System.Exception ex)
        {
            
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("v1/Category")]
    public async Task<IActionResult> CategoryPost(
        [FromServices] ApiContext context,
        [FromBody] CategorieView view
    ){
        if(!ModelState.IsValid)
        return BadRequest(new ResultViewModels<CategorieView>("modelo inválido"));

        var categorie = new Categorie(){
            Name = view.Name,
            Description = view.Description
        };

        try
        {
            await context.Categories.AddAsync(categorie);
            await context.SaveChangesAsync();

          return Ok(new ResultViewModels<CategorieView>(view));
        }
        catch(DbException ex){
            return BadRequest(ex.Message);
        }
        catch (System.Exception ex)
        {
            return BadRequest(new ResultViewModels<CategorieView>(ex.Message));
            throw;
        }
    }

    
}