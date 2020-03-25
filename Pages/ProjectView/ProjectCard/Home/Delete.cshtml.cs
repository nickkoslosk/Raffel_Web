using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.Home
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

        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }

            Projects = await _context.Projects.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD_NUMBER));

            if (Projects == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }

            Projects = await _context.Projects.FindAsync(LEAD_NUMBER);

            if (Projects != null)
            {
                _context.Projects.Remove(Projects);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
