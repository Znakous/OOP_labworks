using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

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

    public void ApplySpell(ISpell spell, IFighterOnTable fighter)
    {
        int targetIndex = _fighters.FindIndex(currentFighter => currentFighter == fighter);
        _fighters[targetIndex] = spell.GetAppliedOn(fighter);
    }

    public IFighterOnTable? SendNextAttacker()
    {
        return GetForPredicate(fighter => fighter.IsAlive && fighter.Attack > Attack.Zero);
    }

    public IFighterOnTable? SendNextPray()
    {
        return GetForPredicate(fighter => fighter.IsAlive);
    }

    private IFighterOnTable? GetForPredicate(Func<IFighterOnTable, bool> predicate)
    {
        if (_fighters.Count == 0)
        {
            return null;
        }

        for (int i = 0; i < _fighters.Count; i++)
        {
            _fighterIndexer.Increment();
            if (predicate(_fighters[_fighterIndexer.Value]))
            {
                IFighterOnTable nextFighter = _fighters[_fighterIndexer.Value];
                _fighterIndexer.Increment();
                return nextFighter;
            }
        }

        return null;
    }
}