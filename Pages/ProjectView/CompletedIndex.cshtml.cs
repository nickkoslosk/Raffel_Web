using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Raffel_Web.Model;

namespace Raffel_Web.Pages.ProjectCard
{


    public class completeModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public completeModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }
        public IList<Projects> Projects { get;set; }
        public SelectList PrioritiesList { get; set; }
        public SelectList EEList { get; set; }

        public string CurrentFilter { get; set; }
        public string EEFilter { get; set; }



        
        public void populateEEDropdown(ApplicationDbContext _context,string selectedPri, object selectedEE = null)
        {
            if(selectedPri == null)
            {
                var EEQuery =(from d in _context.Projects.ToList()
                              orderby d.EE_LEAD
                group d by d.EE_LEAD into d
                select d.First());
                EEList = new SelectList(EEQuery,
                       "EE_LEAD", "EE_LEAD", selectedEE);
            }
            else
            {
                var EEQuery =
                (from d in _context.Projects.ToList()
                where d.PRIORITY.Equals(selectedPri)
                orderby d.EE_LEAD
                group d by d.EE_LEAD into d
                select d.First());
                EEList = new SelectList(EEQuery,
                       "EE_LEAD", "EE_LEAD", selectedEE);
            } 

        }

        public async Task OnGetAsync(string  searchString, string eEString)
        {
            CurrentFilter = searchString;
            EEFilter = eEString;
            IQueryable<Projects> projectsIQ = from s in _context.Projects
                                              where s.PRIORITY.Equals("Completed")
                                              select s;
            

            if(!String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString))
            {
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString) && s.PRIORITY.Equals("Completed"));
                populateEEDropdown(_context, searchString);
            }
            else if (String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) )
            {
                projectsIQ = projectsIQ.Where(s => s.EE_LEAD.Contains(eEString) && s.PRIORITY.Equals("Completed"));
                populateEEDropdown(_context, null);

            }
            else
            {

                populateEEDropdown(_context, null);
            }
            projectsIQ = projectsIQ.OrderByDescending(s => s.LEAD_NUMBER);
            Projects = await projectsIQ.AsNoTracking().ToListAsync();

           
        }

        

    }
}
