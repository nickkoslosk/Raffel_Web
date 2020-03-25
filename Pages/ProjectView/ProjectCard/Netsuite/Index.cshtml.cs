using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.Netsuite
{
    [Authorize(Roles = "Manager, Supervisor, Engineer, Sales ")]
    public class IndexModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;
        public String LEAD { get; set; }
        public Projects project { get; set; }
        public IndexModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NetsuiteEntry> NetsuiteEntry { get; set; }



        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {

            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }

            LEAD = LEAD_NUMBER;
            NetsuiteEntry = await _context.NetsuiteEntry.Where(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER)).ToListAsync();
            project = await _context.Projects.FirstOrDefaultAsync(pt => pt.LEAD_NUMBER.Equals(LEAD_NUMBER));

            if (NetsuiteEntry == null)
            {
                return NotFound();
            }
            return Page();
        }
        /*public async Task<IActionResult> OnPostAsync()
        {
              if (!ModelState.IsValid)
              {
                  return Page();
              }
             // NetsuiteEntry.status
              _context.Attach(NetsuiteEntry).State = EntityState.Modified;

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!NetsuiteEntryExists(NetsuiteEntry.Id))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw;
                  }
              }

              return RedirectToPage("./Index");//, new { NetsuiteEntry.LEAD_NUMBER });

    }*/
        private bool NetsuiteEntryExists(int id)
        {
            return _context.NetsuiteEntry.Any(e => e.Id == id);
        }
        /*
         * something like this for submitting the page and adding a checkmark to the model. model will have to include a submitted check box and approved
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NetsuiteEntry.Add(NetsuiteEntry);
            await _context.SaveChangesAsync();

            // return RedirectToPage("./Index");
            return RedirectToPage("./Index", new { NetsuiteEntry.LEAD_NUMBER });
        }*/
    }
}