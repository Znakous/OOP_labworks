namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class MarkDownProxy : IFormatter
{
    private readonly IFormatter _formatter;

    public MarkDownProxy(IFormatter formatter)
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