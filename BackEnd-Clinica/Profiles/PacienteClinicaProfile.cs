using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Exit.PacienteClinica;
using BackEnd_Clinica.VOS.Exit.Profile;

namespace BackEnd_Clinica.Profiles
{
    public class PacienteClinicaProfile : Profile
    {
        public PacienteClinicaProfile() {

            CreateMap<PacienteClinica, PacienteClinicaVOExit>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Paciente.Id))
                    .ForPath(dest => dest.PacienteClinicaId, opts => opts.MapFrom(x => x.Id))
                        .ForPath(dest => dest.Cadastro, opts => opts.MapFrom(x => x.Paciente.Cadastro))
                           .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Paciente.Name))
                               .ForPath(dest => dest.Cpf, opts => opts.MapFrom(x => x.Paciente.Cpf))
                                   .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Paciente.Email))     
                                        .ForPath(dest => dest.Phone, opts => opts.MapFrom(x => x.Paciente.Phone));
            CreateMap<PacienteClinica, ProfileClinicaVOExit>()
               .ForPath(dest => dest.PacientId, opts => opts.MapFrom(x => x.Paciente.Id))
                    .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Paciente.Name))
                        .ForPath(dest => dest.Receitas, opts => opts.MapFrom(x => x.Receitas))
                            .ForPath(dest => dest.Resultados, opts => opts.MapFrom(x => x.Resultados))
                                .ForPath(dest => dest.Historicos, opts => opts.MapFrom(x => x.Historicos));
                   
        }

    }
}
