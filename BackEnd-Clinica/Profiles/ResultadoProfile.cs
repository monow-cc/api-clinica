using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Receita;
using BackEnd_Clinica.VOS.Enter.Resultado;
using BackEnd_Clinica.VOS.Exit.Receita;
using BackEnd_Clinica.VOS.Exit.Reultado;

namespace BackEnd_Clinica.Profiles
{
    public class ResultadoProfile : Profile
    {
        public ResultadoProfile() {
            CreateMap<ResultadoVOEnter, Resultado>()
                    .ForPath(dest => dest.Description, opts => opts.MapFrom(u => u.Description))
                        .ForPath(dest => dest.PacienteClinicaId, opts => opts.MapFrom(u => u.PacienteClinicaId))
                            .ForMember(dest => dest.ResultadoArquivos, opts => opts.MapFrom(u => u.Arquivos));
            CreateMap<Resultado, ResultadoVOExit>()
                .ForPath(dest => dest.Description, opts => opts.MapFrom(u => u.Description))
                    .ForPath(dest => dest.Created_At, opts => opts.MapFrom(u => u.Created_At))
                        .ForPath(dest => dest.Id, opts => opts.MapFrom(u => u.Id))
                            .ForMember(dest => dest.Arquivos, opts => opts.MapFrom(u => u.ResultadoArquivos));
        }
    }
}
