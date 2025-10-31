using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;

public class Table
{
    private readonly List<IEditableFighter> _fighters;

    private ModuleCounter _currentFighterIndex;

    public IFighter? SendNextFighter()
    {
        if (_fighters.Count == 0)
        {
            return null;
        }

        int iterCount = 0;
        while (iterCount < _fighters.Count && !_fighters[_currentFighterIndex.Value].IsAlive)
        {
            _currentFighterIndex++;
            iterCount++;
        }

        if (iterCount == _fighters.Count)
        {
            return null;
        }

        IFighter nextFighter = _fighters[_currentFighterIndex.Value];
        _currentFighterIndex++;
        return nextFighter;
    }

    public Table Clone()
    {
        return new Table(new List<IEditableFighter>(_fighters), _currentFighterIndex);
    }

    private Table(List<IEditableFighter> fighters, ModuleCounter currentFighterIndex)
    {
        _fighters = fighters;
        _currentFighterIndex = currentFighterIndex;
    }

    public class TableBuilder
    {
        private const int MaxFighters = 7;
        private readonly List<IEditableFighter> _fighters = [];

        public TableBuilder() { }

        public TableBuilder WithFighter(IEditableFighter fighter)
        {
            if (_fighters.Count is MaxFighters)
            {
                throw new ArgumentException("Number of added fighters exceed the threshold");
            }

            _fighters.Add(fighter.Clone());
            return this;
        }

        public Table Build()
        {
            return new Table(_fighters, new ModuleCounter(_fighters.Count));
        }
    }
}