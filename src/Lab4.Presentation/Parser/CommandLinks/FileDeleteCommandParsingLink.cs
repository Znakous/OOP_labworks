using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class FileDeleteCommandParsingLink : CommandParsingLinkBase<FileDeleteCommandBuilder>
{
    public FileDeleteCommandParsingLink(IParameterParsingLink<FileDeleteCommandBuilder> parameterParsers)
        : base(parameterParsers, "delete") { }
}