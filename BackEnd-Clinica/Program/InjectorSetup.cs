using BackEnd_Clinica.Services;

namespace BackEnd_Clinica.Program
{
    public static class InjectorSetup
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<JWTService>();


        }
    }
}
