using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BlogApp.Models;

public class BlogPost
{
    [Key]
    public int Id { get; set; }
    public string? Content { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreationTime { get; set; }
    public virtual ICollection<Comment>? Comments {get; set;}

    public BlogPost()
    {
        CreationTime = DateTime.Now;
    }    
}

