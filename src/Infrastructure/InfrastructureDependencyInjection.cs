using Abstractions.Repositories;
using Abstractions.Validators;
using Infrastructure.CredentialsValidators;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IAccountRepository, InMemoryAccountRepository>();
        services.AddSingleton<ISessionRepository, InMemorySessionRepository>();
        services.AddSingleton<IExecutedTransactionRepository, InMemoryExecutedTransactionRepository>();
        return services;
    }

    public static IServiceCollection AddCredentialValidator(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        string adminPassword = configuration["AdminPassword"] ?? "admin";

        services.AddSingleton<IAdminCredentialsValidator>(new CredentialsValidator(adminPassword));
        return services;
    }
}