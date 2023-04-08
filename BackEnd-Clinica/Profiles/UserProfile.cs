using AutoMapper;
using BackEnd_Clinica.Model;
using BackEnd_Clinica.VOS.Enter.User;

namespace BackEnd_Clinica.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<UserVOEnter, User>()
                   .ForPath(dest => dest.Nome, opts => opts.MapFrom(u => u.Name))
                   .ForPath(dest => dest.Email, opts => opts.MapFrom(u => u.Email))
                   .ForPath(dest => dest.Password, opts => opts.MapFrom(u => u.Password))
                   .ForPath(dest => dest.ClinicaId, opts => opts.MapFrom(u => u.ClinicaId));
                   

        }

    }
}
