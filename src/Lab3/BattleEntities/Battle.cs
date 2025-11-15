using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;

public class Battle
{
    private readonly Table _table1;
    private readonly Table _table2;
    private bool _firstTableTurn;

    public BattleResult Proceed()
    {
        IFighterOnTable? firstTableResponse = _table1.SendNextFighter();
        IFighterOnTable? secondTableResponse = _table2.SendNextFighter();
        while (firstTableResponse is not null
               && secondTableResponse is not null)
        {
            if (_firstTableTurn)
            {
                firstTableResponse.PerformAttackOn(secondTableResponse);
            }
            else
            {
                secondTableResponse.PerformAttackOn(firstTableResponse);
            }

            _firstTableTurn = !_firstTableTurn;
            firstTableResponse = _table1.SendNextFighter();
            secondTableResponse = _table2.SendNextFighter();
        }

        if (firstTableResponse is null
            && secondTableResponse is null)
        {
            return new BattleResult.Draw();
        }

        if (firstTableResponse is null)
        {
            return new BattleResult.WinSecond();
        }

        return new BattleResult.WinFirst();
    }

    public Battle(Table table1, Table table2)
    {
        _table1 = table1.Clone();
        _table2 = table2.Clone();
        _firstTableTurn = true;
    }
}