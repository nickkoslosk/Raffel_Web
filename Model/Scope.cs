using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raffel_Web.Model
{
    public class Scope
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Projects")]
        [Display(Name = "Lead ID")]
        public string LEAD_NUMBER { get; set; }

        [Display(Name = "Original Scope")]
        public string ORIGINAL_SCOPE { get; set; }

        [Display(Name = "Date of Request")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_ENTERED { get; set; }

        [Display(Name = "First Deliverable")]
        public string FIRST_DELIVERABLE { get; set; }

        [Display(Name = "Where to Send")]
        public string WHERE_SEND { get; set; }

        [Display(Name = "Date Needed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_NEEDED { get; set; }

        [Display(Name = "Scope Originator")]
        public string SCOPE_ORIGINATOR { get; set; }

        [Display(Name = "Customer")]
        public string CUSTOMER_SCOPE { get; set; }

        [Display(Name = "Type of Product")]
        public string PRODUCT_TYPE { get; set; }

        [Display(Name = "Similar to PN:")]
        public string SIMILAR_TO { get; set; }

        [Display(Name = "CONNECTIONS")]
        public string CONNECTIONS { get; set; }

        [Required]
        [Display(Name = "EAU")]
        public double EAU { get; set; }
        [Required]
        [Display(Name = "Sell Price")]
        public double TARGET_PRICE { get; set; }



        //any new aditions to this model must be added to the leadnumber edit page
        //if they are not when a leadnumber is changed that field will become null
    }
}
