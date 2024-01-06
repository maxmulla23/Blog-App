using System;

namespace BlogApp.Models;

public class Comment
{
    public int Id {get; set; }
    public int Content { get; set; }
    public BlogPost? BlogPost { get; set; }
    public int BlogPostId{get; set;}
}