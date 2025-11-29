namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract class BattleResult
{
    public sealed class WinFirst : BattleResult { }

    public sealed class WinSecond : BattleResult { }

    public sealed class Draw : BattleResult { }
}