﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class AdminEmployee
    {
        [Key]
        public int EmpID { get; set; }
        
        [Required,MaxLength(50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public bool Gender { get; set; }

        [Column(TypeName = "date")] // sadece date olacak
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Mobile { get; set; }

        [MaxLength(150)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string Phone2 { get; set; }

        [MaxLength(200)]
        public string Picture { get; set; }

        public virtual ICollection<AdminLogin> AdminLogins { get; set; }
    }
}