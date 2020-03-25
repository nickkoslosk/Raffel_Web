using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectView.ProjectCard.Netsuite
{
    [Authorize(Roles = "Manager, Supervisor, Engineer, Sales ")]
    public class CreateModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;
        public String LEAD { get; set; }
        public String PN { get; set; }
        public Projects proj { get; set; }
        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }
        public CreateModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }
        public class BufferedSingleFileUploadDb
        {
            [Required]
            [Display(Name = "File")]
            public IFormFile FormFile { get; set; }
        }
        public async Task<IActionResult> OnGetAsync(string LEAD_NUMBER)
        {
            if (LEAD_NUMBER == null)
            {
                return NotFound();
            }
            LEAD = LEAD_NUMBER;
            

            proj = await _context.Projects.FirstOrDefaultAsync(pt => pt.LEAD_NUMBER.Equals(LEAD));
            PN = proj.PART_NUMBER;
            return Page();

        }

        public List<SelectListItem> Manufac { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "inov", Text = "inov" },
            new SelectListItem { Value = "wellness", Text = "wellness" },
            new SelectListItem { Value = "fortress", Text = "fortress"  },
            new SelectListItem { Value = "somfin", Text = "somfin" },
           
        };

        [BindProperty]
        public NetsuiteEntry NetsuiteEntry { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var file = new NetsuiteEntry.RENDER()
                    {
                        Content = memoryStream.ToArray()
                    };

                    // _context.File.Add(file);


                    _context.NetsuiteEntry.Add(NetsuiteEntry);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                }
            }
                // return RedirectToPage("./Index");
                return RedirectToPage("./Index", new { NetsuiteEntry.LEAD_NUMBER });
        }
    }
}