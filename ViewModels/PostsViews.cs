using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCategories;
using MyCategorieView;
using Mytags;
using MyUser;
using MyUserView;

namespace  MyPostsView;

public class PostView
{
    [Required]
    public string Title { get; set; }
    public string? Image { get; set; }
    public string? Summary { get; set; }
    [Required]
    public string Body { get; set; }
    [Required]
    public string Slug { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

   
    public int Authorid { get; set; }

   
}