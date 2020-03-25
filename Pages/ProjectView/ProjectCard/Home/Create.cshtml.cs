using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.Home
{
    public class CreateModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public CreateModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Projects Projects { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Projects.Add(Projects);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}