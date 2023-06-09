using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.ReceitaArquivo;
using BackEnd_Clinica.VOS.Enter.ResultadoArquivo;
using BackEnd_Clinica.VOS.Exit.ReceitaArquivo;
using BackEnd_Clinica.VOS.Exit.ResultadoArquivo;

namespace BackEnd_Clinica.Profiles
{
    public class ResultadoArquivoProfile : Profile
    {
        public ResultadoArquivoProfile()
        {
            CreateMap<ResultadoArquivoVOEnter, ResultadoArquivo>()
                  .ForPath(dest => dest.Name, opts => opts.MapFrom(u => u.Nome))
                       .ForPath(dest => dest.Link, opts => opts.MapFrom(u => u.Link));
            CreateMap<ResultadoArquivo, ResultadoArquivoVOExit>()
                   .ForPath(dest => dest.Nome, opts => opts.MapFrom(u => u.Name))
                        .ForPath(dest => dest.Link, opts => opts.MapFrom(u => u.Link))
                            .ForPath(dest => dest.Id, opts => opts.MapFrom(u => u.Id));
        }
    }
}
