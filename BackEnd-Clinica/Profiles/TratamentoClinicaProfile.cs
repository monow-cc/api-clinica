using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.TratamentoClinica;
using BackEnd_Clinica.VOS.Exit.TratamentoClinica;

namespace BackEnd_Clinica.Profiles
{
    public class TratamentoClinicaProfile : Profile
    {
        public TratamentoClinicaProfile()
        {
            CreateMap<TratamentoClinica, TratamentoClinicaVOExit>()
                .ForPath(dest => dest.Id, opts => opts.MapFrom(x => x.Id))
                    .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
                        .ForPath(dest => dest.Valor, opts => opts.MapFrom(x => x.Valor))
                            .ForPath(dest => dest.MostrarApp, opts => opts.MapFrom(x => x.MostrarApp));
            CreateMap<TratamentoClinicaVOEnter, TratamentoClinica>()
                   .ForPath(dest => dest.Name, opts => opts.MapFrom(x => x.Name))
                       .ForPath(dest => dest.Valor, opts => opts.MapFrom(x => x.Valor))
                           .ForPath(dest => dest.MostrarApp, opts => opts.MapFrom(x => x.MostrarApp));
        }
    }
}
