using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Pattern.Repository;
using Toolbox.Pattern.Repository.Attributes;

namespace Demo_ASP_Core_MVC.DAL.Entities
{
    [Table("V_Member", "Id_Member")]
    public class MemberEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}