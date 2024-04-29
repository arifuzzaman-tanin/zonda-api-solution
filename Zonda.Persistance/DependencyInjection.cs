using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zonda.Application.Common.Interfaces;

namespace Zonda.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
