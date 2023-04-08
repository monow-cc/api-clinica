namespace BackEnd_Clinica.Model
{
    public class Paciente
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Cpf { get; set; }
    }
}
