using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Models
{
    public class MessageCreateViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Pour envoyer un message, il est necessaire d'avoir un message a envoyer... Merci d'avance. Bisous.")]
        public string Content { get; set; }
    }
}
