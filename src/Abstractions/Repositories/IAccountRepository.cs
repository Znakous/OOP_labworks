using Domain.Entities;
using Domain.Models.ValueObjects;

namespace Abstractions.Repositories;

public interface IAccountRepository
{
    void Add(Account account);

    Account? GetByName(AccountName name);
}