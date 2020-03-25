using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.NoteHistory
{
    public class IndexModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;
        public String LEAD { get; set; }
        public Projects proj { get; set; }
        public String PN { get; set; }
        public Notes noteEdit { get; set; }
        public IndexModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Notes> Notes { get;set; }


            public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER, int? id)
            {

            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }

            LEAD = LEAD_NUMBER;
            Notes = await _context.Notes.Where(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER)).ToListAsync();
            proj = await _context.Projects.FirstOrDefaultAsync(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER));
            PN = proj.PART_NUMBER;
            //noteEdit = await _context.Notes.FirstOrDefaultAsync(m => m.Id == id);
            /* .Select(pt => new Notes
             {
                 LEAD_NUMBER = pt.LEAD_NUMBER
             }).ToListAsync();*/



            if (Notes == null)
            {
                return NotFound();
            }
            return Page();
        }

    }
}
