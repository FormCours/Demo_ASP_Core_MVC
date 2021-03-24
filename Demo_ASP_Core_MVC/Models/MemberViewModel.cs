using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Demo_ASP_Core_MVC.Models
{
    public class MemberLoginViewModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="L'adresse E-mail est necessaire !")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "L'adresse E-mail est invalide")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le mot de passe est necessaire !")]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class MemberRegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "L'adresse E-mail est necessaire !")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le pseudo n'est pas en option :p")]
        [DisplayName("Pseudo")]
        public string Pseudo { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Le mot de passe est requis")]
        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        public string Password1 { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La validation du mot de passe est requis")]
        [Compare(nameof(Password1), ErrorMessage = "Les 2 mots de passe ne sont pas identique !")]
        [DisplayName("Validation du mot de passe")]
        [DataType(DataType.Password)]
        public string Password2 { get; set; }
    }
}
