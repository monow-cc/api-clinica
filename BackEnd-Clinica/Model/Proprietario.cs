namespace BackEnd_Clinica.Model
{
    public class Proprietario
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
