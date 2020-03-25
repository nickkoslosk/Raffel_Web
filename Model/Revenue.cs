using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raffel_Web.Model
{
    public class Revenue
    {

        public int Id { get; set; }

        [Display(Name = "Lead ID")]
        public string LEAD_NUMBER { get; set; }
        [Display(Name = "Project Name")]
        public string PROJECT_NAME { get; set; }

        [Display(Name = "Part Number")]
        public string PART_NUMBER { get; set; }

        [Display(Name = "Priority")]
        public string PRIORITY { get; set; }

        [Display(Name = "Customer")]
        public string CUSTOMER { get; set; }

        [Display(Name = "Deliverable")]
        public string DELIVERABLE { get; set; }

        [Display(Name = "Commit Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? COMMIT_DATE { get; set; }

        [Display(Name = "Electrical Lead")]
        public string EE_LEAD { get; set; }

        [Display(Name = "Mechanical Lead")]
        public string ME_LEAD { get; set; }

        [Display(Name = "Sales person")]
        [StringLength(20, ErrorMessage = "Salesman cannot be longer than 18 characters.")]
        public string SALESMAN { get; set; }

        [Display(Name = "Estimated Actual Revenue")]
        public double EAR { get; set; }








    }
}
