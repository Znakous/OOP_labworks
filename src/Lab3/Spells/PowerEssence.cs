using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerEssence : ISpell
{
    public IFighter GetAppliedOn(IFighter fighter)
    {
        fighter.SetAttack(fighter.Attack + new Attack(5));
        return fighter;
    }
}