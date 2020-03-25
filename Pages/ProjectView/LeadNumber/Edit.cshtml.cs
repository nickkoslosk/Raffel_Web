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

namespace Raffel_Web.Pages.ProjectView.LeadNumber
{
    [Authorize(Roles = "Manager, Supervisor")]
    public class EditModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public EditModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Projects Projects { get; set; }
        public string LEAD { get; set; }
        [BindProperty]
        public Scope Scope { get; set; }
        [BindProperty]
        public IList<Notes> Notes { get; set; }
        [BindProperty]
        public IList<Revision> Revisions { get; set; }
           
        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                
                return NotFound();
            }
            LEAD = LEAD_NUMBER;
            Projects = await _context.Projects.FirstOrDefaultAsync(m => m.LEAD_NUMBER == LEAD);
            Scope = await _context.Scope.FirstOrDefaultAsync(m => m.LEAD_NUMBER == LEAD);
            Notes = await _context.Notes.Where(m => m.LEAD_NUMBER == LEAD).ToListAsync();
            Revisions = await  _context.Revision.Where(m => m.LEAD_NUMBER == LEAD).ToListAsync();
            if (Projects == null)
            {
                return NotFound();
            }
            return Page();
        }

       
        public async Task<IActionResult> OnPostAsync()
        {
            if (Scope.Id != 0) 
            { Scope.LEAD_NUMBER = Projects.LEAD_NUMBER;
                
            }
            
            
            for (int i = 0; i < Notes.Count(); i++)
            {
                Notes[i].LEAD_NUMBER = Projects.LEAD_NUMBER;
            }
            for (int i = 0; i < Revisions.Count(); i++)
            {
                Revisions[i].LEAD_NUMBER = Projects.LEAD_NUMBER;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Projects).State = EntityState.Modified;
            if (Scope.Id != 0)
            { _context.Attach(Scope).State = EntityState.Modified; }
            
            for(int i = 0; i <Notes.Count(); i++)
            {
             _context.Attach(Notes[i]).State = EntityState.Modified;
            }
            for (int i = 0; i < Revisions.Count(); i++)
            {
                _context.Attach(Revisions[i]).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(Projects.Id))
                {
                    return NotFound();
                }
                else if (!ScopeExists(Scope.Id))
                {
                    return NotFound();
                }
                else if (!NotesExists(Notes[0].Id))
                {
                    return NotFound();
                }
                else if (!RevisonExists(Revisions[0].Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/ProjectView/Index");
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
        private bool ScopeExists(int id)
        {
            return _context.Scope.Any(e => e.Id == id);
        }
        private bool NotesExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }
        private bool RevisonExists(int id)
        {
            return _context.Revision.Any(e => e.Id == id);
        }
    }
}
