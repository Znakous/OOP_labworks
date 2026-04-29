using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class CopyCommandParsingLink : CommandParsingLinkBase<FileCopyCommandBuilder>
{
    public CopyCommandParsingLink(IParameterParsingLink<FileCopyCommandBuilder> parameterParsers)
        : base(parameterParsers, "copy") { }
}