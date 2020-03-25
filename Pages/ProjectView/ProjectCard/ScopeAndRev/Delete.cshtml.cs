using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.ScopeAndRev
{
    public class DeleteModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public DeleteModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Scope Scope { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Scope = await _context.Scope.FirstOrDefaultAsync(m => m.Id == id);

            if (Scope == null)
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

            Scope = await _context.Scope.FindAsync(id);

            if (Scope != null)
            {
                _context.Scope.Remove(Scope);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
