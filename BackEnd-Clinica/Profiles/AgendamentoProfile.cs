using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Agendamento;
using BackEnd_Clinica.VOS.Exit.Agendamento;

namespace BackEnd_Clinica.Profiles
{
    public class AgendamentoProfile : Profile
    {
        public AgendamentoProfile() {
            CreateMap<AgendamentoVOEnter, Agendamento>()
                .ForPath(dest => dest.PacienteId, opts => opts.MapFrom(x => x.PacienteId))
                .ForPath(dest => dest.ProfissionalClinicaId, opts => opts.MapFrom(x => x.ProfissionalId))
                .ForPath(dest => dest.TratamentoClinicaId, opts => opts.MapFrom(x => x.TratamentoId))
                .ForPath(dest => dest.Tipo, opts => opts.MapFrom(x => x.Tipo))
                .ForPath(dest => dest.Data, opts => opts.MapFrom(x => x.Data))
                .ForPath(dest => dest.Horario, opts => opts.MapFrom(x => x.Horario))
                .ForPath(dest => dest.Pago, opts => opts.MapFrom(x => x.Pago));
            CreateMap<Agendamento, AgendamentoVOExit>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                .ForPath(dest => dest.PacientId, opts => opts.MapFrom(x => x.PacienteId))
                .ForPath(dest => dest.ProfissionalId, opts => opts.MapFrom(x => x.ProfissionalClinicaId))
                .ForPath(dest => dest.Pago, opts => opts.MapFrom(x => x.Pago))
                .ForPath(dest => dest.Tipo, opts => opts.MapFrom(x => x.Tipo))
                .ForPath(dest => dest.Data, opts => opts.MapFrom(x => x.Data))
                .ForPath(dest => dest.Tratamento, opts => opts.MapFrom(x => x.TratamentoClinica.Name))
                .ForPath(dest => dest.Horario, opts => opts.MapFrom(x => x.Horario))
                .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Paciente.Name));
        }
    }
}
