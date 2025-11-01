using Itmo.ObjectOrientedProgramming.Lab3.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ProtectionCharm : ISpell
{
    public IFighterOnTable GetAppliedOn(IFighterOnTable fighterOnTable)
    {
        fighterOnTable = new MagicShield(fighterOnTable);
        return fighterOnTable;
    }
}