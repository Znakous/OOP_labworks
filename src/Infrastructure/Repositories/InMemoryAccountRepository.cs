using Abstractions.Repositories;
using Domain.Entities;
using Domain.Models.ValueObjects;

namespace Infrastructure.Repositories;

public class InMemoryAccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountName, Account?> _accounts = [];

    public void Add(Account account)
    {
        _accounts[account.Name] = account;
    }

    public Account? GetByName(AccountName name)
    {
        return _accounts.GetValueOrDefault(name);
    }
}