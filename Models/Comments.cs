using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Models;

public class Comment
{
    [Key]
    public int Id {get; set; }
    public int Content { get; set; }
     public int BlogPostId{get; set;}
     [ForeignKey("BlogPostId")]
    public BlogPost? BlogPost { get; set; }
   
}