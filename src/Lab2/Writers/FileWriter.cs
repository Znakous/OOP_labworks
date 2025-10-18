using Itmo.ObjectOrientedProgramming.Lab2.Formatters;

namespace Itmo.ObjectOrientedProgramming.Lab2.Writers;

public class FileWriter : IWriter, IDisposable
{
    private readonly StreamWriter _writer;

    private readonly IFormatter _formatter;

    public FileWriter(string filename, IFormatter formatter)
    {
        _writer = new StreamWriter(filename);
        _formatter = formatter;
    }

    public void WriteHeader(string header)
    {
        _writer.WriteLine(_formatter.FormatHeader(header));
    }

    public void WriteBody(string body)
    {
        _writer.WriteLine(_formatter.FormatText(body));
    }

    public void Dispose()
    {
        _writer.Dispose();
    }
}