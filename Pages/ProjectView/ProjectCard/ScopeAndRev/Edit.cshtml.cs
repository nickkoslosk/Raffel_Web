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

namespace Raffel_Web.Pages.ProjectView.ProjectCard.ScopeAndRev
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
        public Scope Scope { get; set; }
        public List<SelectListItem> deliverables { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Rendering", Text = "Rendering" },
            new SelectListItem { Value = "Rapid Prototype", Text = "Rapid Prototype" },
            new SelectListItem { Value = "Machine Sample", Text = "Machine Sample"  },
            new SelectListItem { Value = "Other", Text = "Other" },

        };
        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }

            Scope = await _context.Scope.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD_NUMBER));

            if (Scope == null)
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

            _context.Attach(Scope).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScopeExists(Scope.LEAD_NUMBER))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", new { Scope.LEAD_NUMBER });
        }


        private bool ScopeExists(string LEAD_NUMBER)
        {
            return _context.Scope.Any(e => e.LEAD_NUMBER.Equals(LEAD_NUMBER));
        }
    }
}
