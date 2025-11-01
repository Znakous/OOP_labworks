using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class ResistanceEssence : ISpell
{
    public IFighterOnTable GetAppliedOn(IFighterOnTable fighterOnTable)
    {
        fighterOnTable.SetHealth(fighterOnTable.Health + new Health(5));
        return fighterOnTable;
    }
}