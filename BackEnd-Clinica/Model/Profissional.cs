namespace BackEnd_Clinica.Model
{
    public class Profissional
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Telefone { get; set; } = default!;
        public string Password { get; set; } = default!;   
        public ICollection<ProfissionalClinica>? Clinicas { get; set; }
    }
}
