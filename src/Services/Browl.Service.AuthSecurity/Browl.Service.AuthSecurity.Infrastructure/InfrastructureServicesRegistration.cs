using Browl.Service.AuthSecurity.Application.Contracts.Email;
using Browl.Service.AuthSecurity.Application.Contracts.Logging;
using Browl.Service.AuthSecurity.Application.Models.Email;
using Browl.Service.AuthSecurity.Infrastructure.EmailService;
using Browl.Service.AuthSecurity.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Browl.Service.AuthSecurity.Infrastructure;

    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
