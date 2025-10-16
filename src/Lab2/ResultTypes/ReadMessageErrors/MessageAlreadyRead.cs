namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.ReadMessageErrors;

public class MessageAlreadyRead : IReadMessageError
{
    public string ErrorMessage { get; }

    public MessageAlreadyRead(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}