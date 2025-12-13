using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class ModeForConnectFlagParser : IFlagArgumentParser<ConnectCommandBuilder>
{
    public FlagParseResult<ConnectCommandBuilder> Parse(IEnumerator<string> arguments, ConnectCommandBuilder builder)
    {
        if (arguments.Current == "-m" && arguments.MoveNext())
        {
            if (arguments.Current == "console")
            {
                return new FlagParseResult<ConnectCommandBuilder>.Failure(
                    builder.WithFactory(new LocalFileSystemFactory()),
                    arguments.MoveNext());
            }

            return new FlagParseResult<ConnectCommandBuilder>.Failure(builder, arguments.MoveNext());
        }

        return new FlagParseResult<ConnectCommandBuilder>.Failure(builder, false);
    }
}