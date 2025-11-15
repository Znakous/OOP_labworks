using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;

public class Battle
{
    private readonly Table _table1;
    private readonly Table _table2;
    private bool _firstTableTurn;

    public Battle(Table table1, Table table2)
    {
        _table1 = table1.Clone();
        _table2 = table2.Clone();
        _firstTableTurn = true;
    }

    public BattleResult Proceed()
    {
        BattleResult? result = null;
        do
        {
            result = PerformStep();
        }
        while (result is null);
        return result;
    }

    private BattleResult? PerformStep()
    {
        IFighterOnTable? firstTableResponse = null;
        IFighterOnTable? secondTableResponse = null;
        if (_firstTableTurn)
        {
            firstTableResponse = _table1.SendNextAttacker();
            secondTableResponse = _table2.SendNextPray();
        }
        else
        {
            firstTableResponse = _table1.SendNextPray();
            secondTableResponse = _table2.SendNextAttacker();
        }

        if (firstTableResponse is null && secondTableResponse is null)
        {
            return new BattleResult.Draw();
        }

        if (firstTableResponse is null)
        {
            return new BattleResult.WinSecond();
        }

        if (secondTableResponse is null)
        {
            return new BattleResult.WinFirst();
        }

        if (_firstTableTurn)
        {
            firstTableResponse.PerformAttackOn(secondTableResponse);
        }
        else
        {
            secondTableResponse.PerformAttackOn(firstTableResponse);
        }

        _firstTableTurn = !_firstTableTurn;
        return null;
    }
}