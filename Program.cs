using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyDbContext;
using MyJwtKey;
using MyMailServices;
using MyTokenServices;

var builder = WebApplication.CreateBuilder(args);
 ConfMVC ( builder);
 TokenConfigure(builder);
 Loadconfiguration(builder);


// configurações de serviços
 void Loadconfiguration(WebApplicationBuilder builder)
 {
    var connectionstring = builder.Configuration.GetConnectionString("Myconnection");
    builder.Services.AddDbContext<ApiContext>(options =>{
        options.UseSqlServer("connectionstring");
    });
     builder.Services.AddDbContext<ApiContext>();
    builder.Services.AddTransient<TokenService>();
    builder.Services.AddTransient<MMailService>();
    builder.Services.AddSwaggerGen(x=>{
        x.SwaggerDoc("v1", new OpenApiInfo(){
            Title = "Vlog",
            Version = "v1"
        } 
        );
    });
 }

//  configurações de performace da aplicação
 void ConfMVC (WebApplicationBuilder builder)
{
    builder.Services.AddResponseCompression(x=>{
        x.Providers.Add<GzipCompressionProvider>();
      
    });
    builder.Services.Configure<GzipCompressionProviderOptions>(x=>{
        x.Level = System.IO.Compression.CompressionLevel.Fastest;
    });
    builder.Services.AddControllers();
    builder.Services.AddMemoryCache();
    builder.Services.AddControllers().AddJsonOptions(x=>{
        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
    });
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(x=>
    {
    x.SuppressModelStateInvalidFilter = true;
     
    });
}

// configurações do token 
void TokenConfigure(WebApplicationBuilder builder)
{
    var Key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    builder.Services.AddAuthentication (x=>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer 
    (x=>
    
        x.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Key),
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false
    });

}


var app = builder.Build();
securityConf(builder);
appconfigure(builder);

// funcionalidades do app
void appconfigure(WebApplicationBuilder builder)
{
    app.MapControllers();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseSwagger();
    app.UseSwaggerUI();
}

// configurações de segurança
void securityConf(WebApplicationBuilder builder)
{
    builder.Configuration.GetValue<string>("JwtKey");
    builder.Configuration.GetValue<string>("ApiName");
    builder.Configuration.GetValue<string>("ApiKey");
    var smtp = Configuration.smtp;
    builder.Configuration.GetSection("ConfSmtp").Bind(smtp);

}

if(app.Environment.IsDevelopment()){
    
    Console.WriteLine("development environment");
}
app.Run();
