using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models;

public class AppUser : IdentityUser
{
    [Display(Name = "Full name")]
    public string? FullName { get; set; }

}