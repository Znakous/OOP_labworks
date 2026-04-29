using Itmo.ObjectOrientedProgramming.Lab4.Core.Errors;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.Errors;

public class ParsingError : IError
{
    public string Message { get; }

    public ParsingError(string message)
    {
        Message = message;
    }
}