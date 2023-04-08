namespace BackEnd_Clinica.Model
{
    public class Clinica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = default!;
        public Guid ProprietarioId { get; set; }
        public Proprietario? Proprietario { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<TratamentoClinica>? TratamentoClinicas { get; set; }
        public ICollection<PacienteClinica>? PacienteClinicas { get; set; }
        public ICollection<ProfissionalClinica>? ProfissionalClinicas { get; set; }
    }
}
