using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyRoles;
using MyUser;

namespace MyUserMap;

public class UsersMaps : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
       builder.ToTable("User");

       builder.HasKey(x=>x.Id);

        builder.Property(x=>x.Id)
        .UseIdentityColumn()
        .ValueGeneratedOnAdd();

       

        builder.Property(x=>x.Name)
        .HasColumnName("Name")
        .HasColumnType("Nvarchar")
        .HasMaxLength(100)
        .IsRequired();
        
        builder.Property(x=>x.Email)
        .HasColumnName("Email")
        .HasColumnType("Nvarchar")
        .HasMaxLength(150)
        .IsRequired();
        

       
        builder.Property(x=>x.PasswordHash)
        .IsRequired()
        .HasColumnName("PasswordHash")
        .HasColumnType("Varchar")
        .HasMaxLength(255);

        builder.Property(x=>x.Slug)
        .HasColumnName("Slug")
        .HasColumnType("Varchar")
        .HasMaxLength(150)
        .IsRequired();

       builder.HasMany(x=>x.Role)
      .WithMany(x=>x.User)
      .UsingEntity<Dictionary<string,object>>(
      role => role.HasOne<Role>()
      .WithMany()
      .HasForeignKey("Idrole")
      .HasConstraintName("FK_ROLE_USER")
      .OnDelete(DeleteBehavior.Cascade),
      user => user.HasOne<User>()
      .WithMany()
      .HasForeignKey("iduser")
      .HasConstraintName("FK_USER_ROLE")
      .OnDelete(DeleteBehavior.Cascade)
      );
        

    }
}
