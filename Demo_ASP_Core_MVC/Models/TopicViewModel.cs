using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Models
{
    public class TopicViewModel
    {
        public Topic Topic { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
