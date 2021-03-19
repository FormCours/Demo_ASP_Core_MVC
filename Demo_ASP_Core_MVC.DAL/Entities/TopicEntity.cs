using System;
using System.Collections.Generic;
using System.Text;
using Toolbox.Pattern.Repository;
using Toolbox.Pattern.Repository.Attributes;

namespace Demo_ASP_Core_MVC.DAL.Entities
{
    [Table("Topic", "Id_Topic")]
    public class TopicEntity : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid IdCreator { get; set; }
    }
}
