namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public class FileFormatter : IFormatter, IDisposable
{
    private readonly StreamWriter _writer;

    public FileFormatter(string filename)
    {
        _writer = new StreamWriter(filename);
    }

    public void WriteHeader(string header)
    {
        _writer.WriteLine(header);
    }

    public void WriteBody(string body)
    {
        _writer.WriteLine(body);
    }

    public void Dispose()
    {
        _writer.Dispose();
    }
}