using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Exit.Clinica;
using BackEnd_Clinica.VOS.Exit.PacienteClinica;

namespace BackEnd_Clinica.Profiles
{
    public class ClinicaProfile : Profile
    {
        public ClinicaProfile() {

            CreateMap<Clinica, ClinicaAuthVOExit>()
                    .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Nome))
                        .ForMember(dest => dest.Tratamentos, opts => opts.MapFrom(x => x.TratamentoClinicas))
                            .ForMember(dest => dest.Profissionais, opts => opts.MapFrom(x => x.ProfissionalClinicas))
                                .ForMember(dest => dest.Pacientes, opts => opts.MapFrom(x => x.PacienteClinicas));
            


        }
    }
}
