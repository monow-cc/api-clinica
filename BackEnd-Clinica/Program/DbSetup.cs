using BackEnd_Clinica.Context;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_Clinica.Program
{
    public static class DbSetup
    {
        public static void DbConnectionSetup(this IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("ApiConnectorString");
            if(connectionString != null) 
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));
        }
    }
}
