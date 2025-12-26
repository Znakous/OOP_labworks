using Contracts.DTOs;
using Contracts.Interfaces;
using Contracts.Requests;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBase
{
    private readonly ISessionService _sessionService;

    public SessionController(ISessionService sessionService)
    {
        _sessionService = sessionService;
    }

    [HttpPost("admin")]
    public ActionResult<SessionDto> StartAdminSession([FromBody] CreateAdminSessionRequest request)
    {
        CreateSessionResponse response = _sessionService.StartAdminSession(request.Password);
        return response switch
        {
            CreateSessionResponse.Success success => Ok(new SessionDto(success.SessionGuid)),
            CreateSessionResponse.BadRequest badRequest => BadRequest(badRequest.ErrorMessage),
            CreateSessionResponse.Unauthorized unauthorized => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("user")]
    public ActionResult<SessionDto> StartUserSession([FromBody] CreateUserSessionRequest request)
    {
        CreateSessionResponse response = _sessionService.StartUserSession(request.AccountName, request.PinCode);
        return response switch
        {
            CreateSessionResponse.Success success => Ok(new SessionDto(success.SessionGuid)),
            CreateSessionResponse.BadRequest badRequest => BadRequest(badRequest.ErrorMessage),
            CreateSessionResponse.Unauthorized unauthorized => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}