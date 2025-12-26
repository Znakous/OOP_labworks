using Domain.Models.ValueObjects;

namespace Domain.Entities;

public abstract record Session(Guid Id, DateTime CreatedAt)
{
    public sealed record AdminSession(Guid Id, DateTime CreatedAt)
        : Session(Id, CreatedAt);

    public sealed record UserSession(Guid Id, AccountName AccountName, DateTime CreatedAt)
        : Session(Id, CreatedAt);
}