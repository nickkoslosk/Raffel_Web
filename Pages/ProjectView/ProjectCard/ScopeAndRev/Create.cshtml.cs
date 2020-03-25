using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.ScopeAndRev
{
    public class CreateModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;
        public String LEAD { get; set; }
        public CreateModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> deliverables { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Rendering", Text = "Rendering" },
            new SelectListItem { Value = "Rapid Prototype", Text = "Rapid Prototype" },
            new SelectListItem { Value = "Machine Sample", Text = "Machine Sample"  },
            new SelectListItem { Value = "Other", Text = "Other" },

        };

        public IActionResult OnGet(string LEAD_NUMBER)
        {
                 LEAD = LEAD_NUMBER;
           // var LEAD = _context.Model.LEAD_NUMBER;

            return Page();
        }

      //  public void OnGetSingleOrder(string LEAD);


        [BindProperty]
        public Scope Scope { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Scope.Add(Scope);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { Scope.LEAD_NUMBER });
        }
    }
}