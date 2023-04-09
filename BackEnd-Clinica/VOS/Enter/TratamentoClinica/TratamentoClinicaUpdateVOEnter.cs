namespace BackEnd_Clinica.VOS.Enter.TratamentoClinica
{
    public class TratamentoClinicaUpdateVOEnter
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Valor { get; set; }
        public float ValorCusto { get; set; }
        public bool MostrarApp { get; set; }
        public string ConnectionID { get; set; }
    }
}
