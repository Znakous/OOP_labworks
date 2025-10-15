namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.MessageAddErrors;

public class MultiMessageAddError : IMessageAddError
{
    public string ErrorMessage { get; }

    public MultiMessageAddError(IReadOnlyList<IMessageAddError> errorMessages)
    {
        ErrorMessage = "Errors occured while sending messages to several recipients\n" +
                       string.Join("\n", errorMessages);
    }
}