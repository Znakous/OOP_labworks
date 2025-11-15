using Itmo.ObjectOrientedProgramming.Lab3.Spells;

namespace Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;

public class Table
{
    private readonly List<IFighterOnTable> _fighters;

    private readonly IIndexer _fighterIndexer;

    public Table(IIndexer fighterIndexer)
    {
        _fighterIndexer = fighterIndexer;
        _fighters = new List<IFighterOnTable>();
    }

    private Table(List<IFighterOnTable> fighters, IIndexer fighterIndexer)
    {
        _fighterIndexer = fighterIndexer;
        _fighters = fighters;
    }

    public Table Clone()
    {
        return new Table(new List<IFighterOnTable>(_fighters), _fighterIndexer);
    }

    public void AddFighter(IFighterOnTable fighter)
    {
        if (_fighters.Count == 7)
        {
            throw new InvalidOperationException("You cannot add more than 7 fighters");
        }

        _fighters.Add(fighter);
        _fighterIndexer.ChangeModule(_fighters.Count);
    }

    public IFighterOnTable? SendNextFighter()
    {
        if (_fighters.Count == 0)
        {
            return null;
        }

        int iterCount = 0;
        while (iterCount < _fighters.Count && !_fighters[_fighterIndexer.Value].IsAlive)
        {
            _fighterIndexer.Increment();
            iterCount++;
        }

        if (iterCount == _fighters.Count)
        {
            return null;
        }

        IFighterOnTable nextFighter = _fighters[_fighterIndexer.Value];
        _fighterIndexer.Increment();
        return nextFighter;
    }

    public void ApplySpell(ISpell spell, IFighterOnTable fighter)
    {
        int targetIndex = _fighters.FindIndex(currentFighter => currentFighter == fighter);
        _fighters[targetIndex] = spell.GetAppliedOn(fighter);
    }
}