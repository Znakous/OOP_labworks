using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public class MagicMirror : ISpell
{
    public IEditableFighter Apply(IEditableFighter fighter)
    {
        int attackValue = fighter.Attack.Value;
        int healthValue = fighter.Health.Value;
        fighter.SetAttack(new Attack(healthValue));
        fighter.SetHealth(new Health(healthValue));
        return fighter;
    }
}