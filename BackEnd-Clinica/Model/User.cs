namespace BackEnd_Clinica.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid ClinicaId { get; set; }
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public Clinica? Clinica { get; set; }
    }
}
