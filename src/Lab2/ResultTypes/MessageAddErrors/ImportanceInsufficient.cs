namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.MessageAddErrors;

public class ImportanceInsufficient : IMessageAddError
{
    public string ErrorMessage { get; }

    public ImportanceInsufficient(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}