using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class FlagParsingLink<T> : ParameterParsingLinkBase<T> where T : class?
{
    private readonly IDictionary<string, IFlagArgumentParser<T>> _flags;

    private FlagParsingLink(IDictionary<string, IFlagArgumentParser<T>> flags)
    {
        _flags = flags;
    }

    public override T? Parse(IEnumerator<string> arguments, T builder)
    {
        if (_flags.ContainsKey(arguments.Current))
        {
            IFlagArgumentParser<T> chosenParser = _flags[arguments.Current];
            if (!arguments.MoveNext())
            {
                return builder;
            }

            FlagParseResult<T> result = chosenParser.Parse(arguments, builder);
            if (result is FlagParseResult<T>.Success)
            {
                builder = result.Builder;
            }

            if (!result.Remaining)
            {
                return builder;
            }
        }

        return Parse(arguments, builder);
    }

    public static FlagParsingLinkBuilder Builder => new FlagParsingLinkBuilder();

    public class FlagParsingLinkBuilder
    {
        private readonly Dictionary<string, IFlagArgumentParser<T>> _parsers = [];

        public FlagParsingLinkBuilder WithFlagParser(IFlagArgumentParser<T> flagParser)
        {
            _parsers.Add(flagParser.Name, flagParser);
            return this;
        }

        public FlagParsingLink<T> Build()
        {
            return new FlagParsingLink<T>(_parsers);
        }
    }
}