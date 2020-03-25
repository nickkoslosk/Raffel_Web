using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Raffel_Web.Model
{
    public class Projects
    {


        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Lead ID")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Lead number should be 7 numbers long.")]
        public string LEAD_NUMBER { get; set; }

        [Required]
        [Display(Name = "Project Name")]
        [StringLength(30, ErrorMessage = "Project name cannot be longer than 30 characters.")]
        public string PROJECT_NAME { get; set; }

        [Display(Name = "Part Number")]
        [StringLength(30, ErrorMessage = "Part number cannot be longer than 30 characters.")]
        public string PART_NUMBER { get; set; }

        [Display(Name = "Date Started")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DATE_STARTED { get; set; }

        [Required]
        [Display(Name = "Priority")]
        [StringLength(20, ErrorMessage = "Priority cannot be longer than 20 characters.")]
        public string PRIORITY { get; set; }

        [Display(Name = "Customer")]
        [StringLength(20, ErrorMessage = "Customer cannot be longer than 20 characters.")]
        public string CUSTOMER { get; set; }

        [Display(Name = "Deliverable")]
        [StringLength(20, ErrorMessage = "Deliverable cannot be longer than 50 characters.")]
        public string DELIVERABLE { get; set; }

        [Display(Name = "Commit Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? COMMIT_DATE { get; set; }

        [Display(Name = "Electrical Lead")]
        [Required]
        [StringLength(18, ErrorMessage = "Electrical lead cannot be longer than 18 characters.")]
        public string EE_LEAD { get; set; }

        [Display(Name = "Mechanical Lead")]
        [Required]
        [StringLength(18, ErrorMessage = "Mechanical lead cannot be longer than 18 characters.")]
        public string ME_LEAD { get; set; }

        [Display(Name = "Alpha Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ALPHA_DATE { get; set; }

        [Display(Name = "Beta Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BETA_DATE { get; set; }

        [Display(Name = "Files to Manufacturing")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? FILES_TO_MANUFACTURE { get; set; }

        [Display(Name = "PPAP Recieved")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? PPAP_RCVD { get; set; }

        [Display(Name = "Tooling Released")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TOOLING_RELEASED { get; set; }

        [Display(Name = "PPAP and Tooling Released for Production")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? TOOLING_COMPLETE { get; set; }

        [Display(Name = "Sales person")]
        [StringLength(20, ErrorMessage = "Salesman cannot be longer than 18 characters.")]
        public string SALESMAN { get; set; }

        [Display(Name = "Username")]
        [StringLength(30, ErrorMessage = "Username cannot be longer than 30 characters.")]
        public string USERNAME { get; set; }

        //any new aditions to this model must be added to the leadnumber edit page
        //if they are not when a leadnumber is changed that field will become null







    }
}
