namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public interface IFormatter
{
    string FormatHeader(string header);

    string FormatText(string text);
}