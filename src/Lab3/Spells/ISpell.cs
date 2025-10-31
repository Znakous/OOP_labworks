namespace Itmo.ObjectOrientedProgramming.Lab3.Spells;

public interface ISpell
{
    IEditableFighter Apply(IEditableFighter fighter);
}