using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class FileMoveCommandParsingLink : CommandParsingLinkBase<FileMoveCommandBuilder>
{
    public FileMoveCommandParsingLink(IParameterParsingLink<FileMoveCommandBuilder> parameterParsers)
        : base(parameterParsers, "move") { }
}