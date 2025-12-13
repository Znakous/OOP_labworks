using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class FlagParsingLink<T> : ParameterParsingLinkBase<T> where T : class?
{
    private readonly IEnumerable<IFlagArgumentParser<T>> _flags;

    private FlagParsingLink(IEnumerable<IFlagArgumentParser<T>> flags)
    {
        _flags = flags;
    }

    public override T? Parse(IEnumerator<string> arguments, T builder)
    {
        bool somethingParsed = false;
        foreach (IFlagArgumentParser<T> flag in _flags)
        {
            FlagParseResult<T> result = flag.Parse(arguments, builder);
            if (result is FlagParseResult<T>.Success success)
            {
                builder = result.Builder;
                somethingParsed = true;
            }

            if (!result.Remaining)
            {
                return builder;
            }
        }

        if (!somethingParsed)
        {
            return builder;
        }

        return Parse(arguments, builder);
    }

    public static FlagParsingLinkBuilder Builder => new FlagParsingLinkBuilder();

    public class FlagParsingLinkBuilder
    {
        private IEnumerable<IFlagArgumentParser<T>> _flags = [];

        public FlagParsingLinkBuilder() { }

        public FlagParsingLinkBuilder WithFlag(IFlagArgumentParser<T> flag)
        {
            _flags = _flags.Append(flag);
            return this;
        }

        public FlagParsingLink<T> Build()
        {
            return new FlagParsingLink<T>(_flags);
        }
    }
}