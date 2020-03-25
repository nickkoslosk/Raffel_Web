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
    public class IndexModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public IndexModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public Scope Scope { get; set; }
        public IList<Revision> Revision { get; set; }
        public String LEAD { get; set; }
        public Projects proj { get; set; }
        
        public String PN { get; set; }
        public double EAR { get; set; }
        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                
                return NotFound();
            }
             LEAD = LEAD_NUMBER;

            Scope = await _context.Scope.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD_NUMBER));
            
                if (Scope != null)
                {
                    EAR = Scope.EAU * Scope.TARGET_PRICE;
                }

                else
                {
                    EAR = 0;

                }
            

            Revision = await _context.Revision.Where(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER)).ToListAsync();
            proj = await _context.Projects.FirstOrDefaultAsync(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER));
            PN = proj.PART_NUMBER;
            
            return Page();
        }

    }
}
