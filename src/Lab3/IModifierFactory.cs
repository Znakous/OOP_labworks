namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IModifierFactory
{
    IFighterOnTable Create(IFighterOnTable fighter);
}