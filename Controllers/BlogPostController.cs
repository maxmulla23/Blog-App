using System;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Controllers;

public class BlogPostController : Controller
{
    private readonly BlogAppContext _context;

    public BlogPostController(BlogAppContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await _context.BlogPosts.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,Content,CreationTime")] BlogPost blogPost)
    {
        if (ModelState.IsValid)
        {
            _context.Add(blogPost);
            blogPost.CreationTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(blogPost);
    }
}