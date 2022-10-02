﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Picture1 { get; set; }

        [MaxLength(500)]
        public string Picture2 { get; set; }

        public bool isActive { get; set; }

        // subcategory
    }
}