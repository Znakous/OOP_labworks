using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ResistanceEssence : ISpell
{
    public IFighter GetAppliedOn(IFighter fighter)
    {
        fighter.SetHealth(fighter.Health + new Health(5));
        return fighter;
    }
}