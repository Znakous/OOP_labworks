using Itmo.ObjectOrientedProgramming.Lab3.Creatures;

namespace Itmo.ObjectOrientedProgramming.Lab3.FighterFactories;

public class MimicChestFactory : IFighterFactory
{
    public IBuilder Create()
    {
        return new MimicChest.MimicChestBuilderDefaultDirector()
            .Direct(new MimicChest.MimicChestBuilder());
    }
}