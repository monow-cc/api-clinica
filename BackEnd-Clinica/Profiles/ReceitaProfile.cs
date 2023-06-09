using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Receita;
using BackEnd_Clinica.VOS.Enter.ReceitaArquivo;
using BackEnd_Clinica.VOS.Exit.Receita;

namespace BackEnd_Clinica.Profiles
{
    public class ReceitaProfile : Profile
    {
        public ReceitaProfile() {
            CreateMap<ReceitaVOEnter, Receita>()
                .ForPath(dest => dest.Description, opts => opts.MapFrom(u => u.Description))
                    .ForPath(dest => dest.PacienteClinicaId, opts => opts.MapFrom(u => u.PacienteClinicaId))
                        .ForMember(dest => dest.ReceitaArquivos, opts => opts.MapFrom(u => u.Arquivos));
            CreateMap<Receita, ReceitaVOExit>()
                .ForPath(dest => dest.Description, opts => opts.MapFrom(u => u.Description))
                    .ForPath(dest => dest.Created_At, opts => opts.MapFrom(u => u.Created_At))
                        .ForPath(dest => dest.Id, opts => opts.MapFrom(u => u.Id))
                            .ForMember(dest => dest.Arquivos, opts => opts.MapFrom(u => u.ReceitaArquivos));

        }
    }
}
