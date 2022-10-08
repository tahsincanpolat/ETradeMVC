using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ETrade.Models
{
    public static class TemporaryUserData // Online kulanıcı id sini tutacak
    {
        public static int UserID { get; set; }
        public static string ReturnUrl { get; set; }
    }
}