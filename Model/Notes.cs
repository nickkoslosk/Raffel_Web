using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raffel_Web.Model
{
    public class Notes
    {


       
        [Key]
        public int Id { get; set; }

        [ForeignKey("Projects")]
        [Display(Name = "Lead ID")]
        public string LEAD_NUMBER { get; set; }

        [Display(Name = "Entry Date")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ENTRY_DATE { get; set; }

        [Required]
        [Display(Name = "Notes")]
        public string NOTES { get; set; }

        [Display(Name = "Entered By")]
        public string NOTE_CREATOR { get; set; }
        //any new aditions to this model must be added to the leadnumber edit page
        //if they are not when a leadnumber is changed that field will become null
    }
}
