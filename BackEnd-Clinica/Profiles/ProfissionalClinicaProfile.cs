using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Exit.Clinica;
using BackEnd_Clinica.VOS.Exit.ProfissionalClinica;

namespace BackEnd_Clinica.Profiles
{
    public class ProfissionalClinicaProfile : Profile
    {
        public ProfissionalClinicaProfile()
        {
            CreateMap<ProfissionalClinica, ProfissionalClinicaVOExit>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                 .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Profissional.Name))
                    .ForPath(dest => dest.Email, opts => opts.MapFrom(x => x.Profissional.Email))
                     .ForPath(dest => dest.Telefone, opts => opts.MapFrom(x => x.Profissional.Telefone))
                      .ForPath(dest => dest.Status, opts => opts.MapFrom(x => x.Status));
            CreateMap<ProfissionalClinica, ClinicaProfVOExit>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.ClinicaId))
                    .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Clinica.Nome))
                        .ForPath(dest => dest.Status, opts => opts.MapFrom(x => x.Status));
        }
    }
}
