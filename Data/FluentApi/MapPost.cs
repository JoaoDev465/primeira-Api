using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Identity.Client;
using MyPosts;
using Mytags;

namespace MyMapPost;

public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Post");

        builder.HasKey(x=>x.Id);

        builder.Property(x=>x.Id)
        .UseIdentityColumn()
        .ValueGeneratedOnAdd();

        builder.Property(x=>x.CreatedAt)
        .IsRequired()
        .HasColumnName("createdeAt")
        .HasColumnType("SMALLDATETIME")
        .HasMaxLength(60)
        .HasDefaultValueSql("GETDATE()");

        builder.Property(x=>x.Image)
        .HasColumnName("Image")
        .HasColumnType("Varchar")
        .HasMaxLength(300);

        builder.Property(x=>x.Title)
        .HasColumnName("Title")
        .HasColumnType("Nvarchar")
        .HasMaxLength(60)
        .IsRequired();

        builder.Property(x=>x.Body)
        .HasColumnName("Body")
        .HasColumnType("varchar")
        .HasMaxLength(2000)
        .IsRequired();
    
        builder.HasOne(x=>x.Author)
        .WithMany(x=>x.Post)
        .HasForeignKey(x=>x.Authorid)
        .HasConstraintName("Users_Posts")
        .OnDelete(DeleteBehavior.Cascade);

    }
}
