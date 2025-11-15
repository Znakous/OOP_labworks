using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CharmMaster : BaseCreature, IFighter
{
    private CharmMaster(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public IFighter Clone()
    {
        return new CharmMaster(Health, Attack);
    }

    public static CharmMasterBuilder Builder => new CharmMasterBuilder();

    public class CharmMasterBuilder
        : CreatureBuilder
    {
        public override IFighter Build()
        {
            return ApplyModifiers(new CharmMaster(Health, Attack));
        }
    }
}