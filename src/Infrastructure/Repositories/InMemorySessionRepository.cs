using Abstractions.Repositories;
using Domain.Entities;

namespace Infrastructure.Repositories;

public class InMemorySessionRepository : ISessionRepository
{
    private readonly Dictionary<Guid, Session?> _sessions = [];

    public void Add(Session session)
    {
        _sessions[session.Id] = session;
    }

    public Session? GetById(Guid sessionId)
    {
        return _sessions.GetValueOrDefault(sessionId);
    }
}