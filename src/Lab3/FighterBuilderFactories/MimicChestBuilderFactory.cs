using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterBuilderFactories;

public class MimicChestBuilderFactory : IFighterBuilderFactory
{
    public IEditableFighterBuilder Create()
    {
        return new MimicChest.MimicChestBuilderDefaultDirector()
            .Direct(new MimicChest.MimicChestEditableFighterBuilder());
    }
}