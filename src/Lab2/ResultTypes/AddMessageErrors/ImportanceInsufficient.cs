namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.AddMessageErrors;

public class ImportanceInsufficient : IMessageAddError
{
    public string ErrorMessage { get; }

    public ImportanceInsufficient(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}