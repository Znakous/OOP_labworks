using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders.FileCommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public class FileRenameCommandParsingLink : CommandParsingLinkBase<FileRenameCommandBuilder>
{
    public FileRenameCommandParsingLink(IParameterParsingLink<FileRenameCommandBuilder> parameterParsers)
        : base(parameterParsers, "rename") { }
}