using System;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class BlogPost
{
    [Key]
    public int Id { get; set; }
    public string? Content { get; set; }

    [DataType(DataType.Date)]
    public DateTime CreationTime { get; set; }
    public virtual ICollection<Comment>? Comments {get; set;}
}
