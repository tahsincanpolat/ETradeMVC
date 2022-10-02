using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        
        [Required, MaxLength(200)]
        public string Name { get; set; }

        [Required, ForeignKey("Supplier")]
        public int SupplierID { get; set; }

        [Required, ForeignKey("SubCategory")]
        public int SubCategoryID { get; set; }
        [Required]
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public string UnitWeight { get; set; }
        public string Size { get; set; }
        public decimal Discount { get; set; }
        public int UnitInStock { get; set; }
        public int? UnitOnOrder { get; set; }
        public bool? ProductAvaiable { get; set; }
        
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public string AltText { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string LongDescription { get; set; }
        public string Picture1 { get; set; }
        public string Picture2 { get; set; }
        public string Picture3 { get; set; }
        public string Picture4 { get; set; }
        public string Notes { get; set; }

        // SubCategory, Supplier, OrderDetails, RecentlyViews, Review, WishList

    }
}