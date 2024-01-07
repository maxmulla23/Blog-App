using System;
using BlogApp.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers;

public class BlogPostController : Controller
{
    private readonly BlogAppContext _context;

    public BlogPostController(BlogAppContext context)
    {
        _context = context;
    }
    
}