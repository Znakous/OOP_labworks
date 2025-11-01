using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class PowerEssence : ISpell
{
    public IFighterOnTable GetAppliedOn(IFighterOnTable fighterOnTable)
    {
        fighterOnTable.SetAttack(fighterOnTable.Attack + new Attack(5));
        return fighterOnTable;
    }
}