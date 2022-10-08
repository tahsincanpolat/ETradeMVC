﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class WishList
    {
        [Key]
        public int WishListID { get; set; }
        
        [Required,ForeignKey("Customer")]
        public int CustomerID { get; set; }
        
        [Required, ForeignKey("Product")]
        public int ProductID { get; set; }
        public bool IsActive { get; set; }


        // Product - Customer
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}