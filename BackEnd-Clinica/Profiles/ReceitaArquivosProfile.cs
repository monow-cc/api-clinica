using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.Receita;
using BackEnd_Clinica.VOS.Enter.ReceitaArquivo;
using BackEnd_Clinica.VOS.Exit.ReceitaArquivo;

namespace BackEnd_Clinica.Profiles
{
    public class ReceitaArquivosProfile : Profile
    {
        public ReceitaArquivosProfile()
        {
            CreateMap<ReceitaArquivoVOEnter, ReceitaArquivos>()
                   .ForPath(dest => dest.Name, opts => opts.MapFrom(u => u.Nome))
                        .ForPath(dest => dest.Link, opts => opts.MapFrom(u => u.Link));
            CreateMap<ReceitaArquivos, ReceitaArquivoVOExit>()
                   .ForPath(dest => dest.Nome, opts => opts.MapFrom(u => u.Name))
                        .ForPath(dest => dest.Link, opts => opts.MapFrom(u => u.Link))
                            .ForPath(dest => dest.Id, opts => opts.MapFrom(u => u.Id));

        }
    }
}
