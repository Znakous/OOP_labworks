using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.Core.PathBuildingStrategies;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.FlagParsers;

public class ModeForConnectParser : IFlagArgumentParser<ConnectCommandBuilder>
{
    public string Name => "-m";

    public FlagParseResult<ConnectCommandBuilder> Parse(IEnumerator<string> arguments, ConnectCommandBuilder builder)
    {
        if (arguments.Current == "local")
        {
            return new FlagParseResult<ConnectCommandBuilder>.Success(
                builder.WithFileSystem(new LocalFileSystem(new UnixPathBuildingStrategy())),
                arguments.MoveNext());
        }

        return new FlagParseResult<ConnectCommandBuilder>.Failure(builder, arguments.MoveNext());
    }
}