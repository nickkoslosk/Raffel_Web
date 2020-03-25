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
    public class RevenueModel : PageModel
    {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;

        public RevenueModel(Raffel_Web.Model.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Projects> Projects { get;set; }
        public IList<Scope> Scope { get; set; }
        public IList<Revenue> Revenue { get; set; }
        public double EAR { get; set; }
        public IQueryable<Revenue> RevenueIQ { get; set; }
        public async Task OnGetAsync()
        {
            Projects = await _context.Projects.ToListAsync();
            Scope = await _context.Scope.ToListAsync();
            Revenue = new List<Revenue>();
  
            for(int i = 0; i < Projects.Count(); i++) {
                Revenue.Add(new Revenue
                {
                    LEAD_NUMBER = " ",
                    PROJECT_NAME = " ",
                    CUSTOMER = " ",
                    PART_NUMBER = " ",
                    PRIORITY = " ",
                    DELIVERABLE = " ",
                    COMMIT_DATE = DateTime.Now,
                    EE_LEAD = " ",
                    ME_LEAD = " ",
                    SALESMAN = " ",
                    EAR = 0
                });
                Revenue[i].LEAD_NUMBER = Projects[i].LEAD_NUMBER;
                Revenue[i].PROJECT_NAME = Projects[i].PROJECT_NAME;
                Revenue[i].CUSTOMER = Projects[i].CUSTOMER;
                Revenue[i].PART_NUMBER = Projects[i].PART_NUMBER;
                Revenue[i].PRIORITY = Projects[i].PRIORITY;
                Revenue[i].DELIVERABLE = Projects[i].DELIVERABLE;
                Revenue[i].COMMIT_DATE = Projects[i].COMMIT_DATE;
                Revenue[i].EE_LEAD = Projects[i].EE_LEAD;
                Revenue[i].ME_LEAD = Projects[i].ME_LEAD;
                Revenue[i].SALESMAN = Projects[i].SALESMAN;
                for (int j = 0; j < Scope.Count(); j++)
                {
                    if (Revenue[i].LEAD_NUMBER == Scope[j].LEAD_NUMBER)
                    {
                        Revenue[i].EAR = Scope[j].EAU * Scope[j].TARGET_PRICE;
                    }

                }
            }
            RevenueIQ = Revenue.AsQueryable();
           // RevenueIQ = RevenueIQ.Where(s => s.EAR != 0);
            RevenueIQ = RevenueIQ.OrderByDescending(s => s.EAR);
           // Revenue = await RevenueIQ.ToListAsync();
            

        }
    }
}
