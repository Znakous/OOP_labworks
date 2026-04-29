using Contracts.Interfaces;
using Contracts.Requests;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("create")]
    public ActionResult CreateAccount([FromBody] CreateAccountRequest request)
    {
        CreateAccountResponse response = _accountService.CreateAccount(
            request.AccountName,
            request.PinCode,
            request.InitialBalance,
            request.SessionId);
        return response switch
        {
            CreateAccountResponse.Success => Ok(response),
            CreateAccountResponse.BadRequest => BadRequest(response),
            CreateAccountResponse.Unauthorised => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}