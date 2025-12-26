using Contracts.DTOs;
using Contracts.Interfaces;
using Contracts.Requests;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BankController : ControllerBase
{
    private readonly IBankService _bankService;

    public BankController(IBankService bankService)
    {
        _bankService = bankService;
    }

    [HttpGet("balance")]
    public ActionResult<BalanceDto> GetBalance([FromBody] BalanceCheckRequest request)
    {
        BalanceResponse response = _bankService.CheckBalance(request.AccountName, request.SessionId);
        return response switch
        {
            BalanceResponse.Success success => Ok(new BalanceDto(success.Balance)),
            BalanceResponse.BadRequest badRequest => BadRequest(badRequest.ErrorMessage),
            BalanceResponse.Unauthorized => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("deposit")]
    public ActionResult<TransactionDto> Deposit([FromBody] DepositRequest request)
    {
        DepositResponse response = _bankService.Deposit(request.AccountName, request.SessionId, request.Amount);
        return response switch
        {
            DepositResponse.Success success => Ok(success.Transaction),
            DepositResponse.BadRequest badRequest => BadRequest(badRequest.ErrorMessage),
            DepositResponse.Unauthorised => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<TransactionDto> WithDraw([FromBody] WithDrawRequest request)
    {
        WithdrawResponse response = _bankService.Withdraw(request.AccountName, request.SessionId, request.Amount);
        return response switch
        {
            WithdrawResponse.Success success => Ok(success.Transaction),
            WithdrawResponse.BadRequest badRequest => BadRequest(badRequest.ErrorMessage),
            WithdrawResponse.Unauthorised => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}