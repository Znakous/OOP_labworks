namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public interface IParameterParsingLink<TBuilder>
{
    IParameterParsingLink<TBuilder> AddNext(IParameterParsingLink<TBuilder> nextLink);

    TBuilder? Parse(IEnumerator<string> arguments, TBuilder builder);
}