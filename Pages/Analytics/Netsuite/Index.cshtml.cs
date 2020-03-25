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
    public class IndexModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public IndexModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<NetsuiteEntry> NetsuiteEntry { get;set; }

        public async Task OnGetAsync()
        {
            NetsuiteEntry = await _context.NetsuiteEntry.ToListAsync();
        }
    }
}
