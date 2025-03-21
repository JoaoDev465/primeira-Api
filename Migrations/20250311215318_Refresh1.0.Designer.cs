﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyDbContext;

#nullable disable

namespace FootboolVlog.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20250311215318_Refresh1.0")]
    partial class Refresh10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyCategories.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("DatePostCategorie")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("Varchar")
                        .HasColumnName("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Varchar")
                        .HasColumnName("Categorie");

                    b.Property<int?>("PostId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categorie", (string)null);
                });

            modelBuilder.Entity("MyPosts.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Authorid")
                        .HasColumnType("int");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar")
                        .HasColumnName("Body");

                    b.Property<int?>("CategorieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(60)
                        .HasColumnType("SMALLDATETIME")
                        .HasColumnName("createdeAt")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Image")
                        .HasMaxLength(300)
                        .HasColumnType("Varchar")
                        .HasColumnName("Image");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("Nvarchar")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("Authorid");

                    b.HasIndex("CategorieId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("MyRoles.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NameRole")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("MyUser.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("Nvarchar")
                        .HasColumnName("Email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("Nvarchar")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("Varchar")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("Varchar")
                        .HasColumnName("Slug");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("Idrole")
                        .HasColumnType("int");

                    b.Property<int>("iduser")
                        .HasColumnType("int");

                    b.HasKey("Idrole", "iduser");

                    b.HasIndex("iduser");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("MyPosts.Post", b =>
                {
                    b.HasOne("MyUser.User", "Author")
                        .WithMany("Post")
                        .HasForeignKey("Authorid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Users_Posts");

                    b.HasOne("MyCategories.Categorie", "Categories")
                        .WithMany("Post")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Author");

                    b.Navigation("Categories");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("MyRoles.Role", null)
                        .WithMany()
                        .HasForeignKey("Idrole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ROLE_USER");

                    b.HasOne("MyUser.User", null)
                        .WithMany()
                        .HasForeignKey("iduser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_USER_ROLE");
                });

            modelBuilder.Entity("MyCategories.Categorie", b =>
                {
                    b.Navigation("Post");
                });

            modelBuilder.Entity("MyUser.User", b =>
                {
                    b.Navigation("Post");
                });
#pragma warning restore 612, 618
        }
    }
}
