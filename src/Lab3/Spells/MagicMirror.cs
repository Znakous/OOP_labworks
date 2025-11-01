using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public IFighterOnTable GetAppliedOn(IFighterOnTable fighterOnTable)
    {
        int attackValue = fighterOnTable.Attack.Value;
        int healthValue = fighterOnTable.Health.Value;
        fighterOnTable.SetAttack(new Attack(healthValue));
        fighterOnTable.SetHealth(new Health(attackValue));
        Console.WriteLine(fighterOnTable.Attack.Value);
        Console.WriteLine(fighterOnTable.Health.Value);
        return fighterOnTable;
    }
}