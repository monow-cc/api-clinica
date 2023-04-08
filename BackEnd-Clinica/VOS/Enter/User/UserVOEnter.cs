using System.ComponentModel.DataAnnotations;

namespace BackEnd_Clinica.VOS.Enter.User
{
    public class UserVOEnter
    {
        [Required(ErrorMessage = "{0} é obrigatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} é obrigatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} é obrigatorio")]
        public string Password { get; set; }
        [Required(ErrorMessage = "{0} é obrigatorio")]
        public Guid ClinicaId { get; set; }
    }
}
