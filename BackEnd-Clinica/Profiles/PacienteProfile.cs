using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Paciente;
using BackEnd_Clinica.VOS.Exit.Paciente;

namespace BackEnd_Clinica.Profiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile() {
            CreateMap<Paciente, PacienteVOExit>()
                .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
                    .ForPath(dest => dest.Cpf, opts => opts.MapFrom(x => x.Cpf))
                        .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                            .ForPath(dest => dest.Password, opts => opts.MapFrom(x => x.Password))
                                .ForPath(dest => dest.Phone, opts => opts.MapFrom(x => x.Phone));
            CreateMap<PacienteVOEnter, Paciente>()
                .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
                    .ForPath(dest => dest.Cpf, opts => opts.MapFrom(x => x.Cpf))
                        .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                            .ForPath(dest => dest.Sexo, opts => opts.MapFrom(x => x.Sexo))
                                .ForPath(dest => dest.Nacimento, opts => opts.MapFrom(x => x.Nascimento));


        }
    }
}
