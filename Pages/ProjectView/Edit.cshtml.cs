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

namespace Raffel_Web.Pages.ProjectCard
{
    [Authorize(Roles = "Manager, Supervisor, Engineer, Sales ")]
    public class EditModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public EditModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }
        
        public List<SelectListItem> Priorities { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value= " ", Text= " "},
            new SelectListItem { Value = "Top", Text = "Top" },
            new SelectListItem { Value = "Regular", Text = "Regular" },
            new SelectListItem { Value = "Hold", Text = "Hold"  },
            new SelectListItem { Value = "In Customer Review", Text = "In Customer Review" },
            new SelectListItem { Value = "Second", Text = "Second" },
            new SelectListItem { Value = "Completed", Text = "Completed"  },
            new SelectListItem { Value = "Graveyard", Text = "Graveyard"  },
        };
        public List<SelectListItem> SalesPeople { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value= " ", Text= " "},
            new SelectListItem { Value = "Cook", Text = "Cook" },
            new SelectListItem { Value = "Hodgson", Text = "Hodgson" },
            new SelectListItem { Value = "Johnson", Text = "Johnson" },
            new SelectListItem { Value = "Otterberg", Text = "Otterberg"  },
            new SelectListItem { Value = "Smith", Text = "Smith" },
            new SelectListItem { Value = "Vaccaro", Text = "Vaccaro"  },
            new SelectListItem { Value = "Ken", Text = "Ken"  },
            new SelectListItem { Value = "Other", Text = "Other"  },
        };
        public List<SelectListItem> customers { get; } = new List<SelectListItem>
        {
            new SelectListItem{Value= " ", Text= " "},
            new SelectListItem{Value= "Albany Industries", Text= "Albany Industries"},
            new SelectListItem{Value= "Ashley", Text= "Ashley"},
            new SelectListItem{Value= "Bradington Young", Text= "Bradington Young"},
            new SelectListItem{Value= "Celebrity Seating", Text= "Celebrity Seating"},
            new SelectListItem{Value= "Changbao", Text= "Changbao"},
            new SelectListItem{Value= "Comfort Design", Text= "Comfort Design"},
            new SelectListItem{Value= "Dutailier", Text= "Dutailier"},
            new SelectListItem{Value= "Elran", Text= "Elran"},
            new SelectListItem{Value= "England", Text= "England"},
            new SelectListItem{Value= "Flexsteel", Text= "Flexsteel"},
            new SelectListItem{Value= "GPLAN", Text= "GPLAN"},
            new SelectListItem{Value= "Greenheck", Text= "Greenheck"},
            new SelectListItem{Value= "Innovative", Text= "Innovative"},
            new SelectListItem{Value= "Irwin", Text= "Irwin"},
            new SelectListItem{Value= "JayMar", Text= "JayMar"},
            new SelectListItem{Value= "Ken", Text= "Ken"},
            new SelectListItem{Value= "Klaussner", Text= "Klaussner"},
            new SelectListItem{Value= "Kroehler", Text= "Kroehler"},
            new SelectListItem{Value= "Lambor", Text= "Lambor"},
            new SelectListItem{Value= "Lane", Text= "Lane"},
            new SelectListItem{Value= "Lippert", Text= "Lippert"},
            new SelectListItem{Value= "Murong", Text= "Murong"},
            new SelectListItem{Value= "NPD", Text= "NPD"},
            new SelectListItem{Value= "Odello", Text= "Odello"},
            new SelectListItem{Value= "Omnia Leather", Text= "Omnia Leather"},
            new SelectListItem{Value= "Palliser", Text= "Palliser"},
            new SelectListItem{Value= "Pride", Text= "Pride"},
            new SelectListItem{Value= "Raffel", Text= "Raffel"},
            new SelectListItem{Value= "Raymour", Text= "Raymour"},
            new SelectListItem{Value= "RTG", Text= "RTG"},
            new SelectListItem{Value= "Skyline", Text= "Skyline"},
            new SelectListItem{Value= "Snow Dogg", Text= "Snow Dogg"},
            new SelectListItem{Value= "Southern Motion", Text= "Southern Motion"},
            new SelectListItem{Value= "Standard Bearings", Text= "Standard Bearings"},
            new SelectListItem{Value= "Synergy", Text= "Synergy"},
            new SelectListItem{Value= "Tempronics", Text= "Tempronics"},
            new SelectListItem{Value= "Ultramek", Text= "Ultramek"},
            new SelectListItem{Value= "VIP", Text= "VIP"},
            new SelectListItem{Value= "Weimer", Text= "Weimer"},
            new SelectListItem{Value= "Williamsburg", Text= "Williamsburg"},
            new SelectListItem{Value= "XM Raffel", Text= "XM Raffel"},
            new SelectListItem{Value= "Bassett Upholstery", Text=  "Bassett Upholstery"},
             new SelectListItem{Value= "Bigbee Industries", Text=  "Bigbee Industries"},
             new SelectListItem{Value= "Bugatti Design", Text=  "Bugatti Design"},
             new SelectListItem{Value= "C&A Marketing Inc", Text=  "C&A Marketing Inc"},
             new SelectListItem{Value= "Camatic", Text=  "Camatic"},
             new SelectListItem{Value= "Celebrity Seating", Text=  "Celebrity Seating"},
             new SelectListItem{Value= "Cinema Crafters", Text=  "Cinema Crafters"},
             new SelectListItem{Value= "Continuum Pedicure Spas LLC", Text=  "Continuum Pedicure Spas LLC"},
             new SelectListItem{Value= "Custom Service Hardware", Text=  "Custom Service Hardware"},
             new SelectListItem{Value= "Ekoform", Text=  "Ekoform"},
             new SelectListItem{Value= "Elite Leather Company", Text=  "Elite Leather Company"},
             new SelectListItem{Value= "England Inc.", Text=  "England Inc."},
             new SelectListItem{Value= "Fairfield Chair", Text=  "Fairfield Chair"},
             new SelectListItem{Value= "Fairmont", Text=  "Fairmont"},
             new SelectListItem{Value= "Filtration Systems INC", Text=  "Filtration Systems INC"},
             new SelectListItem{Value= "Fornirama", Text=  "Fornirama"},
             new SelectListItem{Value= "Fortress, INC", Text=  "Fortress, INC"},
             new SelectListItem{Value= "Franklin Corporation", Text=  "Franklin Corporation"},
             new SelectListItem{Value= "Furniture Support (SMP)", Text=  "Furniture Support (SMP)"},
             new SelectListItem{Value= "Fusion Spa dba SPA AID LTD", Text=  "Fusion Spa dba SPA AID LTD"},
             new SelectListItem{Value= "GFC Global Furniture Comp.", Text=  "GFC Global Furniture Comp."},
             new SelectListItem{Value= "Grupo Suenolar", Text=  "Grupo Suenolar"},
             new SelectListItem{Value= "Imperial Bedding", Text=  "Imperial Bedding"},
             new SelectListItem{Value= "Inorca", Text=  "Inorca"},
             new SelectListItem{Value= "Interiormark LLC", Text=  "Interiormark LLC"},
             new SelectListItem{Value= "International Furniture Direct", Text=  "International Furniture Direct"},
             new SelectListItem{Value= "Ironwood Bed Frames and Mattress", Text=  "Ironwood Bed Frames and Mattress"},
             new SelectListItem{Value= "Irwin Seating Company", Text=  "Irwin Seating Company"},
             new SelectListItem{Value= "JC International- RowOne", Text=  "JC International- RowOne"},
             new SelectListItem{Value= "Julien Beaudoin Ltee", Text=  "Julien Beaudoin Ltee"},
             new SelectListItem{Value= "Kellex Corporation", Text=  "Kellex Corporation"},
             new SelectListItem{Value= "Klaussner Furniture", Text=  "Klaussner Furniture"},
             new SelectListItem{Value= "Kroehler", Text=  "Kroehler"},
             new SelectListItem{Value= "Kwalu", Text=  "Kwalu"},
             new SelectListItem{Value= "Lane by United", Text=  "Lane by United"},
             new SelectListItem{Value= "Leather Creations", Text=  "Leather Creations"},
             new SelectListItem{Value= "Lippert Furniture", Text=  "Lippert Furniture"},
             new SelectListItem{Value= "Lorence Manufacturing", Text=  "Lorence Manufacturing"},
             new SelectListItem{Value= "McNeily's Inc.--Ison Furn", Text=  "McNeily's Inc.--Ison Furn"},
             new SelectListItem{Value= "Meubles Jaymar", Text=  "Meubles Jaymar"},
             new SelectListItem{Value= "Meyer Products", Text=  "Meyer Products"},
             new SelectListItem{Value= "Norwalk", Text=  "Norwalk"},
             new SelectListItem{Value= "North American Medical Co", Text=  "North American Medical Co"},
             new SelectListItem{Value= "OFS Brands - Carolina Furniture", Text=  "OFS Brands - Carolina Furniture"},
             new SelectListItem{Value= "Omnia", Text=  "Omnia"},
             new SelectListItem{Value= "Pacific Furniture Industries", Text=  "Pacific Furniture Industries"},
             new SelectListItem{Value= "Patrick Distributions", Text=  "Patrick Distributions"},
             new SelectListItem{Value= "Pride Mobility Products Corp", Text=  "Pride Mobility Products Corp"},
             new SelectListItem{Value= "Raymour & Flan", Text=  "Raymour & Flan"},
             new SelectListItem{Value= "RJ Binnie", Text=  "RJ Binnie"},
             new SelectListItem{Value= "Salamander Designs", Text=  "Salamander Designs"},
             new SelectListItem{Value= "Sam Moore Furniture", Text=  "Sam Moore Furniture"},
             new SelectListItem{Value= "Sexton Furniture", Text=  "Sexton Furniture"},
             new SelectListItem{Value= "SharperImage.com/Camelot ", Text=  "SharperImage.com/Camelot "},
             new SelectListItem{Value= "Sherrill Furn/Motioncraft", Text=  "Sherrill Furn/Motioncraft"},
             new SelectListItem{Value= "Smith Brothers of Berne", Text=  "Smith Brothers of Berne"},
             new SelectListItem{Value= "Southern Motion", Text=  "Southern Motion"},
             new SelectListItem{Value= "Spectra Home", Text=  "Spectra Home"},
            new SelectListItem{Value= "Other", Text= "Other"},
            new SelectListItem{Value= "None", Text= "None"},
        };
        [BindProperty]
        public Projects Projects { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Projects = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            Projects.DELIVERABLE = Projects.PRIORITY;
            if (Projects == null)
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
            if (Projects.PRIORITY == "Hold" && Projects.DELIVERABLE != "Hold" || 
                Projects.PRIORITY == "Graveyard" && Projects.DELIVERABLE != "Graveyard" || 
                Projects.PRIORITY == "Complete" && Projects.DELIVERABLE != "Complete")
            {
                Projects.COMMIT_DATE = DateTime.Now;
            }
            _context.Attach(Projects).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectsExists(Projects.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProjectsExists(int id)
        {
            return _context.Projects.Any(e => e.Id == id);
        }
    }
}
