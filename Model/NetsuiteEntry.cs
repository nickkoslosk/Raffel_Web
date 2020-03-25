using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Raffel_Web.Model
{
    public class NetsuiteEntry
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Projects")]
        [Display(Name = "Lead ID")]
        public string LEAD_NUMBER { get; set; }

        [Display(Name = "sub-part number")]
        [Required]
        public string PART_SUB { get; set; }

        [Display(Name = "Manufacturing cost")]
        public string MFG_COST { get; set; }

        [Display(Name = "Price")]
        public string PRICE { get; set; }

        [Display(Name = "last update")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime LAST_UPDATE { get; set; }

        [Display(Name = "Manufacturer")]
        public string MANUFACTURER { get; set; }

        [Display(Name = "Sales Description")]
        public string SALES_DES { get; set; }

        [Display(Name = "Purchasing Info")]
        public string PURCHASE_INFO { get; set; }

        [Display(Name = "Submitted by")]
        public string SUB_BY { get; set; }

        [Display(Name = "Render")]
        public class RENDER {
            
            public int Id  { get; set; }
            public byte[] Content { get; set; }
        }
        [Display(Name = "Status")]
        public NetStatus Status { get; set; }
    }

    public enum NetStatus
    {
       Created,  //light grey
       submitted, //yellow
       Approved,  //green
       Rejected   //red

    }
}
