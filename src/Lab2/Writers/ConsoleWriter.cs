using Itmo.ObjectOrientedProgramming.Lab2.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Writers;

public class ConsoleWriter : IWriter
{
    private readonly IFormatter _formatter;

    public ConsoleWriter(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteHeader(string header)
    {
        Console.WriteLine(_formatter.FormatHeader(header));
    }

    public void WriteBody(string body)
    {
        Console.WriteLine(_formatter.FormatText(body));
    }
}