using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Models
{
    public class Member
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
    }
}
