using Andreani.Data.CQRS.Extension;
using onboardingworker.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace onboardingworker.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCQRS<ApplicationDbContext>(configuration);

        services.AddScoped<ApplicationDbContext>();

        return services;
    }
}
