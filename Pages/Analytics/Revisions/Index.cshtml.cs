using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web
{
    public class RevisionModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public RevisionModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Revision> Revision { get;set; }

        public async Task OnGetAsync()
        {
            Revision = await _context.Revision.ToListAsync();
        }
    }
}
