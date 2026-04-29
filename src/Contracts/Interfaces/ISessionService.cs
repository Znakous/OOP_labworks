using Contracts.Responses;

namespace Contracts.Interfaces;

public interface ISessionService
{
    CreateSessionResponse StartAdminSession(string adminPassword);

    CreateSessionResponse StartUserSession(string name, string pinCode);
}