using Itmo.ObjectOrientedProgramming.Lab3.Spells;
using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.BattleEntities;

public class Table
{
    private readonly List<IFighter> _fighters;

    private readonly ISelector _fighterSelector;

    public Table(ISelector fighterSelector)
    {
        _fighterSelector = fighterSelector;
        _fighters = new List<IFighter>();
    }

    private Table(List<IFighter> fighters, ISelector fighterSelector)
    {
        _fighterSelector = fighterSelector;
        _fighters = fighters;
    }

    public Table Clone()
    {
        return new Table(_fighters.Select(fighter => fighter.Clone()).ToList(), _fighterSelector);
    }

    public bool AddFighter(IFighter fighter)
    {
        if (_fighters.Count == 7)
        {
            return false;
        }

        _fighters.Add(fighter);
        return true;
    }

    public void ApplySpell(ISpell spell, IFighter fighter)
    {
        int targetIndex = _fighters.FindIndex(currentFighter => currentFighter == fighter);
        _fighters[targetIndex] = spell.GetAppliedOn(fighter);
    }

    public IFighter? SendNextAttacker()
    {
        return _fighterSelector.GetNextFighter(_fighters.Where(fighter => fighter.IsAlive && fighter.Attack > Attack.Zero));
    }

    public IFighter? SendNextPray()
    {
        return _fighterSelector.GetNextFighter(_fighters.Where(fighter => fighter.IsAlive));
    }
}