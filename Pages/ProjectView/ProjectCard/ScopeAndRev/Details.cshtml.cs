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
    public class DetailsModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public DetailsModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public Scope Scope { get; set; }
        public Revision Revision { get; set; }
        public Projects proj { get; set; }
        public String PN { get; set; }

        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }

            Scope = await _context.Scope.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD_NUMBER));
            Revision = await _context.Revision.FirstOrDefaultAsync(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER));
            proj = await _context.Projects.FirstOrDefaultAsync(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER));
            PN = proj.PART_NUMBER;
            if (Scope == null)
            {
                return NotFound();
            }
            return Page();

            
            
        }
    }
}
