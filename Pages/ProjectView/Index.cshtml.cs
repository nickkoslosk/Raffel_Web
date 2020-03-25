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

namespace Raffel_Web.Pages.ProjectCard{
    [Authorize(Roles = "Manager, Supervisor, Engineer, FieldSales ")]
    public class IndexModel : PageModel {
        private readonly Raffel_Web.Model.ApplicationDbContext _context;
        public IndexModel(Raffel_Web.Model.ApplicationDbContext context) {
            _context = context;
        }
        public IList<Projects> Projects { get; set; }
        public SelectList PrioritiesList { get; set; }
        public SelectList EEList { get; set; }
        public SelectList CustList { get; set; }
        public SelectList SalesList { get; set; }
        public string nextLead { get; set; }
        public IList<Notes> Note {get; set;}
        public string currentNote { get; set; }
        public DateTime LastDate { get; set; }
        public string LastNote { get; set; }
        //public object ViewState { get; private set; }
        
        
       //-----------------start onGet
        public async Task OnGetAsync(string searchString, string eEString, string custString, string salesString, string sortOrder){
            Note = await _context.Notes.ToListAsync();
            IQueryable<Projects> projectsIQ;

            //determine sort variable----------------
            ViewData["LeadSort"] = String.IsNullOrEmpty(sortOrder) ? "Lead" : "";
            ViewData["ProjectSort"] = sortOrder == "project" ? "project_desc" : "project";
            ViewData["custSort"] = sortOrder == "cust" ? "cust_desc" : "cust";
            ViewData["partSort"] = sortOrder == "part" ? "part_desc" : "part";
            ViewData["prioritySort"] = sortOrder == "priority" ? "priority_desc" : "priority";
            ViewData["deliverableSort"] = sortOrder == "deliverable" ? "deliverable_desc" : "deliverable";
            ViewData["commitSort"] = sortOrder == "commit" ? "commit_desc" : "commit";
            ViewData["eeSort"] = sortOrder == "ee" ? "ee_desc" : "ee";
            ViewData["meSort"] = sortOrder == "me" ? "me_desc" : "me";
            ViewData["salesSort"] = sortOrder == "sales" ? "sales_desc" : "sales";


            projectsIQ = from s in _context.Projects
                         where !s.PRIORITY.Equals("Completed") && !s.PRIORITY.Equals("Graveyard") && !s.PRIORITY.Equals("Hold")
                         select s;
            //----------------Limits the project IList based on critera from the two search dropdowns
            if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){ //everything
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && s.EE_LEAD.Contains(eEString)
                && !s.PRIORITY.Equals("Graveyard")
                && !s.PRIORITY.Equals("Completed")
                && !s.PRIORITY.Equals("Hold")
                && s.CUSTOMER.Contains(custString)
                && s.SALESMAN.Contains(salesString));

            } else if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && String.IsNullOrEmpty(salesString)){ //no sales
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && s.EE_LEAD.Contains(eEString)
                && !s.PRIORITY.Equals("Completed") 
                && !s.PRIORITY.Equals("Graveyard") 
                && !s.PRIORITY.Equals("Hold")
                && s.CUSTOMER.Contains(custString));

            } else if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){//no cust
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && s.EE_LEAD.Contains(eEString) 
                && !s.PRIORITY.Equals("Completed") 
                && !s.PRIORITY.Equals("Graveyard") 
                && !s.PRIORITY.Equals("Hold")
                && s.SALESMAN.Contains(salesString));

            } else if (!String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){//no ee
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && !s.PRIORITY.Equals("Completed") 
                && !s.PRIORITY.Equals("Graveyard") 
                && !s.PRIORITY.Equals("Hold")
                && s.CUSTOMER.Contains(custString)
                && s.SALESMAN.Contains(salesString));

            } else if (String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){ //no pri
                projectsIQ = projectsIQ.Where(s => s.EE_LEAD.Contains(eEString)
                && s.CUSTOMER.Contains(custString)
                && s.SALESMAN.Contains(salesString));

            } else if (!String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && String.IsNullOrEmpty(custString) && String.IsNullOrEmpty(salesString)){ //pri and ee
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && s.EE_LEAD.Contains(eEString) 
                && !s.PRIORITY.Equals("Graveyard") 
                && !s.PRIORITY.Equals("Completed") 
                && !s.PRIORITY.Equals("Hold"));

            } else if (!String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && String.IsNullOrEmpty(salesString)){ //pri and cust
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && !s.PRIORITY.Equals("Completed") 
                && !s.PRIORITY.Equals("Graveyard") 
                && !s.PRIORITY.Equals("Hold")
                && s.CUSTOMER.Contains(custString));

            } else if (!String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString) 
                && String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){//pri and sales
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && !s.PRIORITY.Equals("Completed") 
                && !s.PRIORITY.Equals("Graveyard") 
                && !s.PRIORITY.Equals("Hold")
                && s.SALESMAN.Contains(salesString));

            } else if (String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && String.IsNullOrEmpty(salesString)){ //ee and cust
                projectsIQ = projectsIQ.Where(s => s.EE_LEAD.Contains(eEString) 
                && s.CUSTOMER.Contains(custString));

            } else if (String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){//ee and sales
                projectsIQ = projectsIQ.Where(s => s.EE_LEAD.Contains(eEString) 
                && s.SALESMAN.Contains(salesString));

            } else if (String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){//cust and sales
                projectsIQ = projectsIQ.Where(s => s.CUSTOMER.Contains(custString)
                && s.SALESMAN.Contains(salesString));

            } else if (String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString) 
                && String.IsNullOrEmpty(custString) && !String.IsNullOrEmpty(salesString)){  //just sales
                projectsIQ = projectsIQ.Where(s => s.SALESMAN.Contains(salesString));

            } else if (String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString) 
                && !String.IsNullOrEmpty(custString) && String.IsNullOrEmpty(salesString)){ //just cust
                projectsIQ = projectsIQ.Where(s => s.CUSTOMER.Contains(custString));

            } else if (String.IsNullOrEmpty(searchString) && !String.IsNullOrEmpty(eEString) 
                && String.IsNullOrEmpty(custString) && String.IsNullOrEmpty(salesString)){ //just ee
                projectsIQ = projectsIQ.Where(s => s.EE_LEAD.Contains(eEString));
            } else if (!String.IsNullOrEmpty(searchString) && String.IsNullOrEmpty(eEString) 
                && String.IsNullOrEmpty(custString) && String.IsNullOrEmpty(salesString)){ //just pri
                projectsIQ = projectsIQ.Where(s => s.PRIORITY.Contains(searchString)
                && !s.PRIORITY.Equals("Completed") 
                && !s.PRIORITY.Equals("Graveyard") 
                && !s.PRIORITY.Equals("Hold"));
            }
            runPopulates(_context, eEString, searchString);
            projectsIQ = determineSort(projectsIQ, sortOrder);
            //projectsIQ = projectsIQ.OrderByDescending(s => s.LEAD_NUMBER);
            Projects = await projectsIQ.AsNoTracking().ToListAsync();
            findNextLead();
        }
        public IQueryable<Projects> determineSort(IQueryable<Projects> projectsIQ, string sortOrder){
            switch (sortOrder){
                case "Lead":
                projectsIQ = projectsIQ.OrderBy(s => s.LEAD_NUMBER);
                break;
                case "project_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.PROJECT_NAME);
                break;
                case "project":
                projectsIQ = projectsIQ.OrderBy(s => s.PROJECT_NAME);
                break;
                case "cust_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.CUSTOMER);
                break;
                case "cust":
                projectsIQ = projectsIQ.OrderBy(s => s.CUSTOMER);
                break;
                case "part_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.PART_NUMBER);
                break;
                case "part":
                projectsIQ = projectsIQ.OrderBy(s => s.PART_NUMBER);
                break;
                case "priority_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.PRIORITY);
                break;
                case "priority":
                projectsIQ = projectsIQ.OrderBy(s => s.PRIORITY);
                break;
                case "deliverable_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.DELIVERABLE);
                break;
                case "deliverable":
                projectsIQ = projectsIQ.OrderBy(s => s.DELIVERABLE);
                break;
                case "commit_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.COMMIT_DATE);
                break;
                case "commit":
                projectsIQ = projectsIQ.OrderBy(s => s.COMMIT_DATE);
                break;
                case "ee_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.EE_LEAD);
                break;
                case "ee":
                projectsIQ = projectsIQ.OrderBy(s => s.EE_LEAD);
                break;
                case "me_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.ME_LEAD);
                break;
                case "me":
                projectsIQ = projectsIQ.OrderBy(s => s.ME_LEAD);
                break;
                case "sales_desc":
                projectsIQ = projectsIQ.OrderByDescending(s => s.SALESMAN);
                break;
                case "sales":
                projectsIQ = projectsIQ.OrderBy(s => s.SALESMAN);
                break;
                default:
                projectsIQ = projectsIQ.OrderByDescending(s => s.LEAD_NUMBER);
                break;
            }
            return projectsIQ;
        }
        //the following method allows the next concurrent lead number to be used when ceating a new project
        public void findNextLead() {
            var maxyear = 0;
            var maxLead = 0;
            var highLead = "";
            var stringyear = "";
            foreach (var item in Projects){
                var nextYear = item.LEAD_NUMBER.Substring(1, 2);
                int i = 0;
                if (!Int32.TryParse(nextYear, out i)){
                    i = -1;
                }
                if (maxyear <= i){

                    maxyear = i;
                }
            }
            stringyear = maxyear.ToString();
            foreach (var item in Projects){
                int j = 0;
                if (item.LEAD_NUMBER.Substring(1, 2).Equals(stringyear)){
                    highLead = item.LEAD_NUMBER.Substring(3);
                    if (!Int32.TryParse(highLead, out j)){
                        j = -1;
                    }
                    if (maxLead <= j){
                        maxLead = j;
                    }
                }
            }
            maxLead++;
             if (maxLead.ToString().Length <= 1){
                nextLead = "L" + stringyear + "000" + maxLead;
            } else if (maxLead.ToString().Length <= 2){
                nextLead = "L" + stringyear + "00" + maxLead;
            } else if (maxLead.ToString().Length <= 3){
                nextLead = "L" + stringyear + '0' + maxLead;
            } else{
                nextLead = "L" + stringyear + maxLead;
            }
        }

        public void runPopulates(ApplicationDbContext _context, string searchString, string eEString){
            populateEEDropdown(_context, searchString);
            populatePrioritiesDropdown(_context, eEString);
            populateCustDropdown(_context);
            populatesalesDropdown(_context);
        }
        //---------------------- this method populates the dropdowns for 
        //---------------------- priorities based on the selected projects Ilist from the method below
        public void populatePrioritiesDropdown(ApplicationDbContext _context, string selectedEE, object selectedPriority = null){
            if (selectedEE == null){
                var prioritiesQuery =
                                  (from d in _context.Projects.ToList()
                                   where d.PRIORITY != "Completed" & d.PRIORITY != "Graveyard" & d.PRIORITY != "Hold"
                                   orderby d.PRIORITY
                                   group d by d.PRIORITY into d
                                   select d.First());

                PrioritiesList = new SelectList(prioritiesQuery,
                            "PRIORITY", "PRIORITY", selectedPriority);
            } else{
                var prioritiesQuery =
                                  (from d in _context.Projects.ToList()     
                                   where d.EE_LEAD.Equals(selectedEE) & d.PRIORITY != "Completed" & d.PRIORITY != "Graveyard" & d.PRIORITY != "Hold"
                                   orderby d.PRIORITY
                                   group d by d.PRIORITY into d
                                   select d.First());
                PrioritiesList = new SelectList(prioritiesQuery,
                            "PRIORITY", "PRIORITY", selectedPriority);
            }
        }
        //---------------------- this method populates the dropdowns for Electrical Engineers
        //----------------------  based on the selected projects Ilist from the method below
        public void populateEEDropdown(ApplicationDbContext _context, string selectedPri, object selectedEE = null){
            if (selectedPri == null){
                var EEQuery = (from d in _context.Projects.ToList()
                               orderby d.EE_LEAD
                               group d by d.EE_LEAD into d
                               select d.First());
                EEList = new SelectList(EEQuery,
                       "EE_LEAD", "EE_LEAD", selectedEE);
            } else{
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
        public void populateCustDropdown(ApplicationDbContext _context, object selectedCust = null){
             var CustQuery = (from d in _context.Projects.ToList()
                               orderby d.CUSTOMER
                               group d by d.CUSTOMER into d
                               select d.First());
                CustList = new SelectList(CustQuery,
                       "CUSTOMER", "CUSTOMER", selectedCust);
        }
        public void populatesalesDropdown(ApplicationDbContext _context, object selectedSales = null){
                var SalesQuery = (from d in _context.Projects.ToList()
                               orderby d.SALESMAN
                                  group d by d.SALESMAN into d
                               select d.First());
                SalesList = new SelectList(SalesQuery,
                       "SALESMAN", "SALESMAN", selectedSales);  
        }
    }
}
