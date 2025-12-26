using Contracts.DTOs;
using Contracts.Interfaces;
using Contracts.Requests;
using Contracts.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Presentation.Controllers;

[ApiController]
[Route("history")]
public class HistoryController : ControllerBase
{
    private readonly ITransactionHistoryService _transactionHistoryService;

    public HistoryController(ITransactionHistoryService transactionHistoryService)
    {
        _transactionHistoryService = transactionHistoryService;
    }

    [HttpGet]
    public ActionResult<TransactionHistoryDto> History([FromBody] TransactionHistoryRequest request)
    {
        TransactionHistoryResponse response = _transactionHistoryService.History(request.AccountName, request.SessionId);
        return response switch
        {
            TransactionHistoryResponse.Success success => Ok(new TransactionHistoryDto(success.Transactions)),
            TransactionHistoryResponse.BadRequest badRequest => BadRequest(badRequest.ErrorMessage),
            TransactionHistoryResponse.Unauthorised => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}