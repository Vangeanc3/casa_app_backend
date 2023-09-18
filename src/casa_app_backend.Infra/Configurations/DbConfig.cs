using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using casa_app_backend.Infra.Context;

namespace casa_app_backend.Infra.Configurations
{
    public static class DbConfig
    {
        public static void AddDbConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                opts =>
                {
                    opts.UseLazyLoadingProxies().UseNpgsql(configuration.GetConnectionString("RotinaDeCasaConnection"));
                });
        }
    }
}