using System;
namespace RPG.Interfaces
{
    public interface IWeapon
    {
        string Name { get; set; }

        int Damage { get; set; }

        int Durability { get; set; }

    }
}
