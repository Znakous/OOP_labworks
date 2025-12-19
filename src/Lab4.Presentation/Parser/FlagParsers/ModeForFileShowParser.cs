using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class ModeForFileShowParser : IFlagArgumentParser<FileShowCommandBuilder>
{
    public string Name => "-m";

    public FlagParseResult<FileShowCommandBuilder> Parse(IEnumerator<string> arguments, FileShowCommandBuilder builder)
    {
        if (arguments.Current == "console")
        {
            return new FlagParseResult<FileShowCommandBuilder>.Success(
                builder.WithOutput(new ConsoleOutput()),
                arguments.MoveNext());
        }

        return new FlagParseResult<FileShowCommandBuilder>.Failure(builder, arguments.MoveNext());
    }
}