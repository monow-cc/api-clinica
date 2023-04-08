using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace BackEnd_Clinica.VOS.Enter.User
{
    public class AuthVOEnter
    {
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Email { get; set; }

   
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Password { get; set; }
    }
}
