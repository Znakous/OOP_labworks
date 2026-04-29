namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

public abstract class ParameterParsingLinkBase<TBuilder> : IParameterParsingLink<TBuilder>
    where TBuilder : class?
{
    private IParameterParsingLink<TBuilder>? _nextLink;

    public IParameterParsingLink<TBuilder> AddNext(IParameterParsingLink<TBuilder> nextLink)
    {
        if (_nextLink is null)
        {
            _nextLink = nextLink;
        }
        else
        {
            _nextLink.AddNext(nextLink);
        }

        return this;
    }

    public abstract TBuilder? Parse(IEnumerator<string> arguments, TBuilder builder);

    protected TBuilder? CallNext(IEnumerator<string> arguments, TBuilder builder)
    {
        return _nextLink?.Parse(arguments, builder) ?? builder;
    }
}