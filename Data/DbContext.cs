using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyCategories;
using MyMapCategory;
using MyMapPost;
using MyPosts;
using MyRoles;
using Mytags;
using MyUser;
using MyUserMap;

namespace MyDbContext;

public class ApiContext : DbContext
{
    public ApiContext(DbContextOptions<ApiContext> options)
        :base(options)
    {
    }

    public DbSet<Categorie> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }

  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.ApplyConfiguration (new UsersMaps());
         modelBuilder.ApplyConfiguration(new PostMap());
         modelBuilder.ApplyConfiguration(new CategoryMap());
    }
}