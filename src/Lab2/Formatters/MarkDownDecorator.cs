namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkDownDecorator : IFormatter
{
    private readonly IFormatter _formatter;

    public MarkDownDecorator(IFormatter formatter)
    {
        _formatter = formatter;
    }

    public void WriteHeader(string header)
    {
        _formatter.WriteHeader(header);
    }

    public void WriteBody(string body)
    {
        _formatter.WriteBody(body);
    }
}