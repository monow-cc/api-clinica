using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Profissional;
using BackEnd_Clinica.VOS.Exit.Clinica;
using BackEnd_Clinica.VOS.Exit.Profissional;

namespace BackEnd_Clinica.Profiles
{
    public class ProfissionalProfile : Profile
    {
        public ProfissionalProfile() {
            CreateMap<ProfissionalVOEnter, Profissional>()
                .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
                    .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Email))
                        .ForPath(dest => dest.Password, opts => opts.MapFrom(x => x.Password));
            CreateMap<Profissional, ProfissionalAuthVOExit>()
                .ForPath(dest => dest.Nome, opts => opts.MapFrom(x => x.Name))
                    .ForPath(dest => dest.Clinicas, opts => opts.MapFrom(x => x.Clinicas));
        }
    }
}
