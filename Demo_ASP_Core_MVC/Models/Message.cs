using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm}")]
        public DateTime SubmitDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy - hh:mm}")]
        public DateTime? UpdateDate { get; set; }

        public Member Creator { get; set; }
    }
}
