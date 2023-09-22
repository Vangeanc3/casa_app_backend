using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using casa_app_backend.Infra.Context;

namespace casa_app_backend.Infra.Configurations
{
    public static class DbConfig
    {
        public static void AddDbConfigPostGreSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                opts =>
                {
                    opts.UseLazyLoadingProxies().UseNpgsql(configuration.GetConnectionString("PostGreSqlConnection"));
                });
        }

        public static void AddDbConfigSqlServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(
                opts =>
                {
                    opts.UseLazyLoadingProxies().UseSqlServer(configuration.GetConnectionString("SqlServeConnection"));
                });
        }
    }
}