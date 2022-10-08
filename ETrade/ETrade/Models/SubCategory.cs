using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }
  
        [Required, ForeignKey("Category")]
        public int CategoryID { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Picture1 { get; set; }

        public string Picture2 { get; set; }

        public bool isActive { get; set; }

        // category
        public virtual Category Category { get; set; }
        // products
        public virtual ICollection<Product> Products { get; set; }


    }
}