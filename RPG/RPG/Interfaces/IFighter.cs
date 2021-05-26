using System;
namespace RPG.Interfaces
{
    public interface IFighter
    {
        public void Attack(IFighter toAttack);

        public void Defend(int dmg);

    }
}
