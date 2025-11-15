using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionCharm : ISpell
{
    public IFighter GetAppliedOn(IFighter fighter)
    {
        fighter = new MagicShield(fighter);
        return fighter;
    }
}