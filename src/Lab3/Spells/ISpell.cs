namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public interface ISpell
{
    IFighterOnTable GetAppliedOn(IFighterOnTable fighterOnTable);
}