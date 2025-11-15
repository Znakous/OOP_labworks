using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : BaseCreature, IFighterOnTable
{
    private MimicChest(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public override void PerformAttackOn(IFighterOnTable enemy)
    {
        Health = Health > enemy.Health ? Health : enemy.Health;
        Attack = Attack > enemy.Attack ? Attack : enemy.Attack;
        enemy.TakeDamage(Attack);
    }

    public IFighterOnTable Clone()
    {
        return new MimicChest(Health, Attack);
    }

    public static MimicChestBuilder Builder => new MimicChestBuilder();

    public class MimicChestBuilder : CreatureOnTableBuilder
    {
        public override MimicChest Build()
        {
            return new MimicChest(Health, Attack);
        }
    }
}