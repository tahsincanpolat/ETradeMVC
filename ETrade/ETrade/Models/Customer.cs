using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Organization { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
        public string AltEmail { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Address { get; set; }
        public string Picture { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreateDate { get; set; }
        public string Notes { get; set; }

        // Order details , wishlist, Review , Recently Views

    }
}