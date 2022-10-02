using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required,ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Required, ForeignKey("Product")]
        public int ProductID { get; set; }

        public string Name { get; set; } // Yorum yapan kişinin adı
        public string Email { get; set; } // Yorum yapan kişinin email
        [Required]
        public string Comment { get; set; }
        public int Rate { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeleted { get; set; }

        // Customer, Product

    }
}