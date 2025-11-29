namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public interface ISpell
{
    IFighter GetAppliedOn(IFighter fighter);
}