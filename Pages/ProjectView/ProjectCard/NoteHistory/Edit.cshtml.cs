using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.NoteHistory
{
    [Authorize(Roles = "Manager, Supervisor, Engineer, Sales ")]
    public class EditModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public EditModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Notes Notes { get; set; }
        public Notes noteEdit { get; set; }
        public async Task<IActionResult> OnGetAsync( int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Notes = await _context.Notes.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD_NUMBER));
            Notes = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            if (Notes == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Notes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotesExists(Notes.LEAD_NUMBER))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { Notes.LEAD_NUMBER });
        }

        private bool NotesExists(string LEAD_NUMBER)
        {
            return _context.Notes.Any(e => e.LEAD_NUMBER.Equals(LEAD_NUMBER));

        }
    }
}
