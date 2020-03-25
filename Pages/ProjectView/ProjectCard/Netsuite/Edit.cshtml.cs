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

namespace Raffel_Web.Pages.ProjectView.ProjectCard.Netsuite
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
        public NetsuiteEntry NetsuiteEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NetsuiteEntry = await _context.NetsuiteEntry.FirstOrDefaultAsync(m => m.Id == id);

            if (NetsuiteEntry == null)
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

            return RedirectToPage("./Index", new { NetsuiteEntry.LEAD_NUMBER });

        }

        private bool NetsuiteEntryExists(int id)
        {
            return _context.NetsuiteEntry.Any(e => e.Id == id);
        }
    }
}
