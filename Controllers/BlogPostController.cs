using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.Data;
using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.Controllers;

public class BlogPostController : Controller
{
    private readonly BlogAppContext _context;

    public BlogPostController(BlogAppContext context)
    {
        _context = context;
    }
    //Get all Blogs
    public async Task<IActionResult> Index()
    {
        return View(await _context.BlogPosts.ToListAsync());
    }

    //get blog details
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var blogPost = await _context.BlogPosts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogPost == null)
        {
            return NotFound();
        }

        return View(blogPost);
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
            //blogPost.CreationTime = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(blogPost);
    }
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var blogPost = await _context.BlogPosts.FindAsync(id);
        if (blogPost == null)
        {
            return NotFound();
        }
        return View(blogPost);
    }

    [HttpPut]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> Edit (int id, [Bind("id,CreationTime, Content")] BlogPost blogPost)
    {
        if (id != blogPost.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(blogPost);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(blogPost.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(blogPost);
    }
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var blogPost = await _context.BlogPosts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogPost == null)
        {
            return NotFound();
        }

        return View(blogPost);
    }
    [HttpDelete]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var blogPost = await _context.BlogPosts.FindAsync(id);
        if (blogPost != null)
        {
            _context.BlogPosts.Remove(blogPost);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BlogPostExists(int id)
    {
        return _context.BlogPosts.Any(e => e.Id == id);
    }
}