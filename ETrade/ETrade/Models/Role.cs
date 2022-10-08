using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }
        public string Description { get; set; }

        // Login
        public virtual ICollection<AdminLogin> AdminLogins { get; set; }
    }
}