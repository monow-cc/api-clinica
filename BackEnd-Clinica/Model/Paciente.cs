namespace BackEnd_Clinica.Model
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long Cadastro { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Phone { get; set; }
        public string? Rua { get; set; }
        public string? Numero { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Altura { get; set; }
        public string? Peso { get; set; }
        public long Cpf { get; set; }
        public int Sexo { get; set; }
        public DateTime? Nacimento { get; set; }
    }
}
