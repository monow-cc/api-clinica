using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace BackEnd_Clinica.VOS.Exit.User
{
    public class AuthVOExit
    {
        [JsonPropertyName("token")]
        [BindProperty(Name = "token")]
        public string Token { get; set; }
    }

    
}
