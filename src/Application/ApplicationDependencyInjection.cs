using Application.Services;
using Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ApplicationDependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IBankService, BankService>();
        services.AddScoped<ISessionService, SessionsService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITransactionHistoryService, TransactionHistoryService>();
        return services;
    }
}