using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using role2.Data;

namespace role2.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly role2.Data.ApplicationDbContext _context;

        public DeleteModel(role2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Departments Departments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departments = await _context.Departments.FirstOrDefaultAsync(m => m.DID == id);

            if (Departments == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departments = await _context.Departments.FindAsync(id);

            if (Departments != null)
            {
                _context.Departments.Remove(Departments);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
