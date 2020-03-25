using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectCard
{
    public class DeleteModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public DeleteModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projects Projects { get; set; }
        public Scope Scope { get; set; }
        public IList<Notes> Notes { get; set; }
        public IList<Revision> Revisions { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projects = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            
            if (Projects == null)
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

            Projects = await _context.Projects.FindAsync(id);
            Scope = await _context.Scope.FirstOrDefaultAsync(s => s.LEAD_NUMBER == Projects.LEAD_NUMBER);
            Notes = await _context.Notes.Where(pt => pt.LEAD_NUMBER == Projects.LEAD_NUMBER).ToListAsync();
            Revisions = await _context.Revision.Where(pt => pt.LEAD_NUMBER == Projects.LEAD_NUMBER).ToListAsync();

            if (Projects != null)
            {
                _context.Projects.Remove(Projects);
                if (Scope != null) {
                    _context.Scope.Remove(Scope);
                }
                if(Notes != null)
                {
                    foreach (var note in Notes)
                    {
                        _context.Notes.Remove(note);
                    }
                }
                if (Revisions != null)
                {
                    foreach (var rev in Revisions)
                    {
                        _context.Revision.Remove(rev);
                    }
                }


                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
