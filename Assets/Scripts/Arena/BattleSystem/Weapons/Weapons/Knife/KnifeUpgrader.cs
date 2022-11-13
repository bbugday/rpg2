using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeUpgrader : WeaponUpgrader
{
    KnifeThrower knifeThrower;

    public KnifeUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
        descriptions = new string[] {"Knife oluştur", "damage++"};
        maxWeaponLevel = 2;
        weaponName = "Knife";
        sprite = Resources.Load<Sprite>("images/knife");
    }

    public override void Upgrade()
    {
        switch (weaponLevel)
        {
            case(0):
                knifeThrower = InstantiateWeapon<KnifeThrower>();
                break;
            case(1):
                knifeThrower.attackDamage += 5;
                break;
            default:
                throw new UnityException("Invalid level");
        }
        weaponLevel++;
    }
}
