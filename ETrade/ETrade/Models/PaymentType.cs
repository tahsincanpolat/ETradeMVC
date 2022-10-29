using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class PaymentType
    {
        [Key]
        public int PayTypeID { get; set; }
        
        [Required,MaxLength(100)]
        public string TypeName { get; set; } // Kredi kartı , havale, çek
       
        [MaxLength(150)]
        public string Description { get; set; }

        // Payments
        public virtual ICollection<Payment> Payments { get; set; }
    }
}