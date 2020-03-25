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
    public class DetailsModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public DetailsModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
