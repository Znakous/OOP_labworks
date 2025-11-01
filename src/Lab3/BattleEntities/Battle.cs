using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;

public class Battle
{
    private readonly Table _table1;
    private readonly Table _table2;
    private bool _firstTableTurn;

    public BattleResult Proceed()
    {
        SendNextFighterResult firstTableResponse = _table1.SendNextFighter();
        SendNextFighterResult secondTableResponse = _table2.SendNextFighter();
        while (firstTableResponse is SendNextFighterResult.Success firstTableSuccess
               && secondTableResponse is SendNextFighterResult.Success secondTableSuccess)
        {
            if (_firstTableTurn)
            {
                firstTableSuccess.Fighter.PerformAttackOn(secondTableSuccess.Fighter);
            }
            else
            {
                secondTableSuccess.Fighter.PerformAttackOn(firstTableSuccess.Fighter);
            }

            _firstTableTurn = !_firstTableTurn;
            firstTableResponse = _table1.SendNextFighter();
            secondTableResponse = _table2.SendNextFighter();
        }

        if (firstTableResponse is SendNextFighterResult.Failure
            && secondTableResponse is SendNextFighterResult.Failure)
        {
            return new BattleResult.Draw();
        }

        if (firstTableResponse is SendNextFighterResult.Failure)
        {
            return new BattleResult.WinSecond();
        }

        return new BattleResult.WinFirst();
    }

    private Battle(Table table1, Table table2, bool firstTableTurn)
    {
        _table1 = table1;
        _table2 = table2;
        _firstTableTurn = firstTableTurn;
    }

    public interface IFirstTableBattleBuilder
    {
        ISecondTableBattleBuilder WithFirstTable(Table firstTable);
    }

    public interface ISecondTableBattleBuilder
    {
        IBattleBuilder WithSecondTable(Table secondTable);
    }

    public interface IBattleBuilder
    {
        Battle Build();
    }

    public static IFirstTableBattleBuilder Builder => new BattleBuilder();

    public class BattleBuilder
        : IFirstTableBattleBuilder,
            ISecondTableBattleBuilder,
            IBattleBuilder
    {
        private Table? _table1;
        private Table? _table2;

        public ISecondTableBattleBuilder WithFirstTable(Table firstTable)
        {
            _table1 = firstTable ?? throw new ArgumentNullException(nameof(firstTable));
            return this;
        }

        public IBattleBuilder WithSecondTable(Table secondTable)
        {
            _table2 = secondTable ?? throw new ArgumentNullException(nameof(secondTable));
            return this;
        }

        public Battle Build()
        {
            if (_table1 is null)
            {
                throw new ArgumentNullException(nameof(_table1));
            }

            if (_table2 is null)
            {
                throw new ArgumentNullException(nameof(_table2));
            }

            return new Battle(_table1.Clone(), _table2.Clone(), true);
        }
    }
}