﻿namespace BackEnd_Clinica.Model
{
    public class TratamentoClinica
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Valor { get; set; }
        public bool MostrarApp { get; set; }
        public Guid ClinicaId { get; set; }
        public Clinica? Clinica { get; set; }
    }
}
