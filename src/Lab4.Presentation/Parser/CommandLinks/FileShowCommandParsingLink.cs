using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class FileShowCommandParsingLink : CommandParsingLinkBase<FileShowCommandBuilder>
{
    public FileShowCommandParsingLink(IParameterParsingLink<FileShowCommandBuilder> parameterParsers)
        : base(parameterParsers, "show") { }
}