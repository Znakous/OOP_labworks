using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public class Battle
{
    private readonly Table _table1;
    private readonly Table _table2;
    private bool _firstTableTurn;

    public BattleResult Proceed()
    {
        IFighter? fromTable1 = _table1.SendNextFighter();
        IFighter? fromTable2 = _table2.SendNextFighter();
        while (fromTable1 is not null && fromTable2 is not null)
        {
            if (_firstTableTurn)
            {
                fromTable1.PerformAttackOn(fromTable2);
            }
            else
            {
                fromTable2.PerformAttackOn(fromTable1);
            }

            _firstTableTurn = !_firstTableTurn;
            fromTable1 = _table1.SendNextFighter();
            fromTable2 = _table2.SendNextFighter();
        }

        if (fromTable1 is null && fromTable2 is null)
        {
            return new BattleResult.Draw();
        }

        if (fromTable1 is null)
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

    public class BattleBuilder
        : IFirstTableBattleBuilder,
            ISecondTableBattleBuilder,
            IBattleBuilder
    {
        private Table? _table1;
        private Table? _table2;

        public BattleBuilder() { }

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