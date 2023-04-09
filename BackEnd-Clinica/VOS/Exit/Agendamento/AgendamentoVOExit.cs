namespace BackEnd_Clinica.VOS.Exit.Agendamento
{
    public class AgendamentoVOExit
    {
        public Guid Id { get; set; }
        public Guid PacientId { get; set; }
        public Guid ProfissionalId { get; set; }
        public DateTime Data { get; set; }
        public string Name { get; set; }
        public string Tratamento { get; set; }
        public string Valor { get; set; }
        public string Horario { get; set; }
        public string Tipo { get; set; }
        public bool Pago { get; set; }
        public int Metodo { get; set; }
    }
}
