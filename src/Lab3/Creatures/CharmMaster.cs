using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class CharmMaster : BaseCreature, IFighterOnTable
{
    private CharmMaster(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public IFighterOnTable Clone()
    {
        return new CharmMaster(Health, Attack);
    }

    public static CharmMasterBuilder Builder => new CharmMasterBuilder();

    public class CharmMasterBuilder
        : CreatureOnTableBuilder
    {
        public override CharmMaster Build()
        {
            return new CharmMaster(Health, Attack);
        }
    }
}