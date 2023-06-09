namespace BackEnd_Clinica.Model
{
    public class ResultadoArquivo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public Guid ResultadoId { get; set; }
        public Resultado? Resultado { get; set; }
    }
}
