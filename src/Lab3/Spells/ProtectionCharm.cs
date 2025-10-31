using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionCharm : ISpell
{
    public IEditableFighter Apply(IEditableFighter fighter)
    {
        return new MagicShield(fighter);
    }
}