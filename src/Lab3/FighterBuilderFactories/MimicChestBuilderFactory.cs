using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class MimicChestBuilderFactory : IFighterBuilderFactory
{
    public IFighterOnTableBuilder Create()
    {
        return MimicChest.DefaultBuilder;
    }
}