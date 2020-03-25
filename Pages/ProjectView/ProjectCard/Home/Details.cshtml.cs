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
    public class DetailsModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public DetailsModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Notes> Note { get; set; }
        public string lastNote { get; set; }
        public DateTime lastDate { get; set; }
        public Projects Projects { get; set; }
        public Scope scope { get; set; }
        public double EAR { get; set; }
        
        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }
            Note = await _context.Notes.Where(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER)).ToListAsync();

            foreach (Notes notes in Note)
            {
                if (lastNote == null)
                {
                    lastDate = notes.ENTRY_DATE;
                    lastNote = notes.NOTES;
                }

                int result = DateTime.Compare(lastDate, notes.ENTRY_DATE);
                if (result < 0)
                    lastNote = notes.NOTES;
                
            }

            Projects = await _context.Projects.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD_NUMBER));
            scope = await _context.Scope.FirstOrDefaultAsync(m => m.LEAD_NUMBER.Equals(LEAD_NUMBER));
            if (scope != null)
            {
                EAR = scope.TARGET_PRICE * scope.EAU;
            }
            else
            {
                EAR = 0;
            }
            if (Projects == null)
            {
                return NotFound();
            }
            return Page();
        }
      
    }
}
