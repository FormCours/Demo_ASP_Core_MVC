using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_ASP_Core_MVC.Models
{
    public class TopicViewModel
    {
        public Topic Topic { get; set; }
        public IEnumerable<Message> Messages { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Pour envoyer un message, il est necessaire d'avoir un message a envoyer... Merci d'avance. Bisous.")]
        public string NewMessage { get; set; }
    }

    public class TopicCreationViewModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage = "Un titre est necessaire")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings =false, ErrorMessage = "Le contenu n'est pas optionnel :o")]
        [MaxLength(4000, ErrorMessage = "Trop long...")]
        public string Content { get; set; }
    }
}
