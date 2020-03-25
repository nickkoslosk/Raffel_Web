using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raffel_Web.Model
{
    public class Revision
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Scope")]
        [Display(Name = "Lead ID")]
        public string LEAD_NUMBER { get; set; }


        [Display(Name = "Date Entered")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_ENTERED { get; set; }


        [Display(Name = "Revision Request")]
        public string REV_DETAILS { get; set; }

        [Display(Name = "Entered By")]
        public string ENTERED_BY { get; set; }


        [Display(Name = "Completed By")]
        public string COMPLETE_BY { get; set; }

        [Display(Name = "Date Completed")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_COMPLETE { get; set; }

        //any new aditions to this model must be added to the leadnumber edit page
        //if they are not when a leadnumber is changed that field will become null


    }
}
