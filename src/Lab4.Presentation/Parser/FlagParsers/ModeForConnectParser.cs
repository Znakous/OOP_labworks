using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystemFactories;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class ModeForConnectParser : IFlagArgumentParser<ConnectCommandBuilder>
{
    public FlagParseResult<ConnectCommandBuilder> Parse(IEnumerator<string> arguments, ConnectCommandBuilder builder)
    {
        if (arguments.Current == "-m" && arguments.MoveNext())
        {
            if (arguments.Current == "local")
            {
                return new FlagParseResult<ConnectCommandBuilder>.Failure(
                    builder.WithFactory(new LocalFileSystemFactory(new UnixPathHandler())),
                    arguments.MoveNext());
            }

            return new FlagParseResult<ConnectCommandBuilder>.Failure(builder, arguments.MoveNext());
        }

        return new FlagParseResult<ConnectCommandBuilder>.Failure(builder, false);
    }
}