using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class RecentlyView
    {
        [Key]
        public int RViewID { get; set; }

        [Required, ForeignKey("Customer")]
        public int CustomerID { get; set; }
        [Required, ForeignKey("Product")]
        public int ProductID { get; set; }
        public DateTime ViewDate { get; set; }
        public string Notes { get; set; }

        // Customer - Product
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }

    }
}