using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyCategories;

namespace MyMapCategory;

public class CategoryMap : IEntityTypeConfiguration<Categorie>
{
    public void Configure(EntityTypeBuilder<Categorie> builder)
    {
        builder.ToTable("Categorie");

        builder.HasKey(x=>x.Id);

        builder.Property(x=>x.Id)
        .UseIdentityColumn()
        .ValueGeneratedOnAdd();

        builder.Property(x=>x.Name)
        .HasColumnName("Categorie")
        .HasColumnType("Varchar")
        .HasMaxLength(100)
        .IsRequired();

        builder.Property(x=>x.Description)
        .HasColumnName("Description")
        .HasColumnType("Varchar")
        .HasMaxLength(300);

        builder.Property(x=>x.CreatedAt)
        .HasColumnName("DatePostCategorie")
        .HasDefaultValueSql("GetDate()");

       builder.HasMany(x=>x.Post)
       .WithOne(x=>x.Categories)
       .HasForeignKey(x=>x.CategorieId)
       .OnDelete(DeleteBehavior.Cascade);
    }
}
