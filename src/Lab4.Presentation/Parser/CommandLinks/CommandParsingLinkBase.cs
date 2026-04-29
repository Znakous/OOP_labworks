using Itmo.ObjectOrientedProgramming.Lab4.Core.CommandBuilders;
using Itmo.ObjectOrientedProgramming.Lab4.Core.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.ParameterLinks;

namespace Itmo.ObjectOrientedProgramming.Lab4.Presentation.Parser.CommandLinks;

public abstract class CommandParsingLinkBase<TBuilder> : ParsingLinkBase where TBuilder : ICommandBuilder, new()
{
    private readonly IParameterParsingLink<TBuilder> _parameterParsers;

    private readonly string _name;

    protected CommandParsingLinkBase(IParameterParsingLink<TBuilder> parameterParsers, string name)
    {
        _parameterParsers = parameterParsers;
        _name = name;
    }

    public override ICommand? Parse(IEnumerator<string> arguments)
    {
        if (arguments.Current == _name)
        {
            var builder = new TBuilder();
            if (!arguments.MoveNext())
            {
                return builder.Build();
            }

            TBuilder? response = _parameterParsers.Parse(arguments, builder);
            return response?.Build() ?? null;
        }

        return CallNext(arguments);
    }
}