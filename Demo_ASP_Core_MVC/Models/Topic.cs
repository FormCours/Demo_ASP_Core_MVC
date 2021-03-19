using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Models
{
    public class Topic
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Member Creator { get; set; }
    }

    public class TopicWithLastMessage : Topic
    {
        public Message LastMessage { get; set; }
    }
}
