using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Pattern.Repository;
using Toolbox.Pattern.Repository.Attributes;

namespace Demo_ASP_Core_MVC.DAL.Entities
{
	[Table("Message", "Id_Message")]
    public class MessageEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid IdTopic { get; set; }
        public Guid IdMember { get; set; }
    }
}
