using Itmo.ObjectOrientedProgramming.Lab3.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab3.Creatures;

public class MimicChest : BaseCreature, IEditableFighter
{
    public void TakeDamage(Attack damage)
    {
        Health = Health.TakeDamage(damage);
    }

    public void PerformAttackOn(IFighter enemy)
    {
        Health = Health > enemy.Health ? Health : enemy.Health;
        Attack = Attack > enemy.Attack ? Attack : enemy.Attack;
        enemy.TakeDamage(Attack);
    }

    public void SetHealth(Health health)
    {
        Health = health;
    }

    public void SetAttack(Attack attack)
    {
        Attack = attack;
    }

    public IEditableFighter Clone()
    {
        return new MimicChest(Health, Attack);
    }

    private MimicChest(Health health, Attack attack)
        : base(health, attack) { }

    public class MimicChestBuilder : CreatureBuilder<MimicChestBuilder, MimicChest>
    {
        public override MimicChest Build()
        {
            return new MimicChest(Health, Attack);
        }
    }

    public class MimicChestBuilderDefaultDirector
    {
        public MimicChestBuilder Direct(MimicChestBuilder builder)
        {
            return builder
                .WithAttack(1)
                .WithHealth(1);
        }
    }
}