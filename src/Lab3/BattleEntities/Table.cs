using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;

public class Table
{
    private readonly List<IFighterOnTable> _fighters;

    private ModuleCounter _currentFighterIndex;

    public SendNextFighterResult SendNextFighter()
    {
        if (_fighters.Count == 0)
        {
            return new SendNextFighterResult.Failure();
        }

        int iterCount = 0;
        while (iterCount < _fighters.Count && !_fighters[_currentFighterIndex.Value].IsAlive)
        {
            _currentFighterIndex++;
            iterCount++;
        }

        if (iterCount == _fighters.Count)
        {
            return new SendNextFighterResult.Failure();
        }

        IFighterInCombat nextFighterInCombat = _fighters[_currentFighterIndex.Value];
        _currentFighterIndex++;
        return new SendNextFighterResult.Success(nextFighterInCombat);
    }

    public void ApplySpell(ISpell spell, IFighterOnTable fighter)
    {
        int targetIndex = _fighters.FindIndex(currentFighter => currentFighter == fighter);
        _fighters[targetIndex] = spell.GetAppliedOn(fighter);
    }

    public Table Clone()
    {
        return new Table(new List<IFighterOnTable>(_fighters), _currentFighterIndex);
    }

    private Table(List<IFighterOnTable> fighters, ModuleCounter currentFighterIndex)
    {
        _fighters = fighters;
        _currentFighterIndex = currentFighterIndex;
    }

    public class TableBuilder
    {
        private const int MaxFighters = 7;
        private readonly List<IFighterOnTable> _fighters = [];

        public TableBuilder() { }

        public TableBuilder WithFighter(IFighterOnTable fighterOnTable)
        {
            if (_fighters.Count is MaxFighters)
            {
                throw new ArgumentException("Number of added fighters exceed the threshold");
            }

            _fighters.Add(fighterOnTable);
            return this;
        }

        public Table Build()
        {
            return new Table(_fighters, new ModuleCounter(_fighters.Count));
        }
    }
}