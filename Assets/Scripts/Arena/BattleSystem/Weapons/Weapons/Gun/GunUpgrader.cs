using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrader : WeaponUpgrader
{
    Gun gun;

    public GunUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
        descriptions = new string[] {"Gun oluştur", "damage++"};
        maxWeaponLevel = 2;
        weaponName = "Gun";
        sprite = Resources.Load<Sprite>("images/arrow");
    }

    public override void Upgrade()
    {
        switch (weaponLevel)
        {
            case(0):
                gun = InstantiateWeapon<Gun>();
                break;
            case(1):
                gun.attackDamage += 5;
                break;
            default:
                throw new UnityException("Invalid level");
        }
        weaponLevel++;
    }
}
