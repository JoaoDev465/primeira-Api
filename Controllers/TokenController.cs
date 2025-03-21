using System.Data.Common;
using MailKit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDbContext;
using MyExtenssionViews;
using MyloginViewModels;
using MyMailServices;
using MyResultViews;
using MyTokenServices;
using MyUser;
using MyUserView;
using SecureIdentity.Password;

namespace MyTokenController;

[ApiController]
public class TokenController:ControllerBase
{
    [AllowAnonymous]
    [HttpPost("v1/users/login")]
    public async Task<IActionResult> PostLog(
        [FromServices]
    ApiContext context,
        [FromServices]
        TokenService service,
        [FromBody]
        loginViewModel login
        )
        {
            if(!ModelState.IsValid)
                return BadRequest (new ResultViewModels<string>(ModelState.GetErrors()));

            
               
                
                var user= await context.Users.
                AsNoTracking()
                .Include (x=>x.Role).
                FirstOrDefaultAsync(x=>x.Email == login.Email);
          
                if (user == null)
                return NotFound(new ResultViewModels<string>("erro : X&3 - usuário não encontrado"));

                
                if (!PasswordHasher.Verify(user.PasswordHash,login.Password ))
                return StatusCode (401, "acesso não autorizado, senha inválida");
            try
            {
                var token = service.TokenGenerator(user);
                return Ok (new ResultViewModels<string>(token,null));
            }
            
            catch
            {
                return BadRequest (new ResultViewModels<string>("erro : X@5 - falha interna no servidor"));
            }
           
        }

        
        [HttpPost("v1/users")]
        public async Task<IActionResult> CreateUsers(
            [FromServices]
            ApiContext context,
            [FromServices]
            MMailService mail,
            [FromBody]
            UserView view
            
             
        )
        {
           
            if(!ModelState.IsValid)
                return BadRequest(new ResultViewModels<string>(ModelState.GetErrors()));
                
           
           
            var user = new User()
            {
              Email = view.Email,
              Name = view.Name,
              Slug = view.Slug,
               
            };
            var password = PasswordGenerator.Generate(16,true,false);
            user.PasswordHash=PasswordHasher.Hash(password);

           
            
            try
            {
                await context.Users.AddAsync(user);
               await context.SaveChangesAsync();

               return Ok(new ResultViewModels<dynamic>(new{
                user = user.Email,password
               }));
            }
            catch(DbException)
            {
                return StatusCode(400,"falha interna na comunicação com os dados");
            }
            catch(Exception)
            {
                return BadRequest(new ResultViewModels<string>("erro x$3 - falha interna no servidor"));
            }
        
        }
}