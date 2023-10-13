using casa_app_backend.Application.Interfaces;
using casa_app_backend.Application.Interfaces.Repository;
using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Application.Services;
using casa_app_backend.Infra.Repository;
using casa_app_backend.Services;
using Microsoft.Extensions.DependencyInjection;

namespace casa_app_backend.Infra.Configurations
{
    public static class InfraConfig
    {
        public static void AddInfra(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IEmailSender, EmailSenderService>();  
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
                 
            services.AddScoped<IEmailRepository, EmailRepository>(); 
            services.AddScoped(typeof(IBaseRepositoryEF<>), typeof(BaseRepositoryEF<>));
            
        }
    }
}