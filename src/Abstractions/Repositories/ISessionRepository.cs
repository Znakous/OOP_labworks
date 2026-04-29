using Domain.Entities;

namespace Abstractions.Repositories;

public interface ISessionRepository
{
    void Add(Session session);

    Session? GetById(Guid sessionId);
}