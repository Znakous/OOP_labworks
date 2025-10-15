namespace Itmo.ObjectOrientedProgramming.Lab2.Formatters;

public interface IFormatter
{
    IFormatter WriteHeader(string header);

    IFormatter WriteBody(string body);
}