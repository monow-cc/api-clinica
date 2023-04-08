using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Exit.PacienteClinica;

namespace BackEnd_Clinica.Profiles
{
    public class PacienteClinicaProfile : Profile
    {
        public PacienteClinicaProfile() {

            CreateMap<PacienteClinica, PacienteClinicaVOExit>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Paciente.Id))
                   .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Paciente.Name))
                       .ForPath(dest => dest.Cpf, opts => opts.MapFrom(x => x.Paciente.Cpf))
                           .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Paciente.Email))     
                                .ForPath(dest => dest.Phone, opts => opts.MapFrom(x => x.Paciente.Phone));
        }

    }
}
