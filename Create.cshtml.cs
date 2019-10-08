﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using role2.Data;

namespace role2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly role2.Data.ApplicationDbContext _context;

        public CreateModel(role2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Departments Departments { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Departments);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}