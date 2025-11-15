using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : BaseCreature, IFighter
{
    private MimicChest(Health health, Attack attack)
    {
        Health = health;
        Attack = attack;
    }

    public override void PerformAttackOn(IFighter enemy)
    {
        Health = Health > enemy.Health ? Health : enemy.Health;
        Attack = Attack > enemy.Attack ? Attack : enemy.Attack;
        enemy.TakeDamage(Attack);
    }

    public IFighter Clone()
    {
        return new MimicChest(Health, Attack);
    }

    public static MimicChestBuilder Builder => new MimicChestBuilder();

    public class MimicChestBuilder : CreatureBuilder
    {
        public override IFighter Build()
        {
            return ApplyModifiers(new MimicChest(Health, Attack));
        }
    }
}