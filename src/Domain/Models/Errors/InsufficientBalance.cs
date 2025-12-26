using Domain.Interfaces;

namespace Domain.Models.Errors;

public class InsufficientBalance : IError
{
    public string Message { get; }

    public InsufficientBalance(string opertion)
    {
        Message = $"Insufficient balance for {opertion}";
    }
}