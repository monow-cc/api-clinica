namespace BackEnd_Clinica.Model
{
    public class ReceitaArquivos
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public Guid ReceitaId { get; set; }
        public Receita? Receita { get; set; }
    }
}
