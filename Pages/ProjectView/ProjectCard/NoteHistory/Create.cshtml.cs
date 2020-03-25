using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.NoteHistory
{
    public class CreateModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;
        public String LEAD { get; set; }
        public CreateModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string LEAD_NUMBER)
        {
            LEAD = LEAD_NUMBER;
            return Page();
        }

        [BindProperty]
        public Notes Notes { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Notes.Add(Notes);
            await _context.SaveChangesAsync();

            return RedirectToPage("/ProjectView/ProjectCard/Home/Details", new { Notes.LEAD_NUMBER });
        }
    }
}