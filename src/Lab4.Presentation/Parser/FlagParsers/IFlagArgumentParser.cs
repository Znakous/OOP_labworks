using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public interface IFlagArgumentParser<TBuilder>
{
    string Name { get; }

    FlagParseResult<TBuilder> Parse(IEnumerator<string> arguments, TBuilder builder);
}