using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectCard
{
    public class CreateModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        
        public CreateModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Priorities { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Top", Text = "Top" },
            new SelectListItem { Value = "Regular", Text = "Regular" },
            new SelectListItem { Value = "Hold", Text = "Hold"  },
            new SelectListItem { Value = "In Customer Review", Text = "In Customer Review" },
            new SelectListItem { Value = "Second", Text = "Second" },
            new SelectListItem { Value = "Completed", Text = "Completed"  },
        };
        public List<SelectListItem> SalesPeople { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Cook", Text = "Cook" },
            new SelectListItem { Value = "Hodgson", Text = "Hodgson" },
            new SelectListItem { Value = "Johnson", Text = "Johnson" },
            new SelectListItem { Value = "Otterberg", Text = "Otterberg"  },
            new SelectListItem { Value = "Smith", Text = "Smith" },
            new SelectListItem { Value = "Vaccaro", Text = "Vaccaro"  },
            new SelectListItem { Value = "Ken", Text = "Ken"  },
            new SelectListItem { Value = "Other", Text = "Other"  },
        };
        public String LEAD { get; set; }
        public IActionResult OnGet(string nextLead)
        {
            LEAD = nextLead;
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