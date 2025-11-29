namespace Itmo.ObjectOrientedProgramming.Lab3;

public interface IModifierFactory
{
    IFighter Create(IFighter fighter);
}