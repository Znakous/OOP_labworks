namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record SendNextFighterResult
{
    public sealed record Success(IFighterOnTable Fighter) : SendNextFighterResult { }

    public sealed record Failure : SendNextFighterResult { }
}