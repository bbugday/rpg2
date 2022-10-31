using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireWeaponUpgrader : WeaponUpgrader
{
    FireWeapon fireWeapon;
    
    public FireWeaponUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
        descriptions = new string[] {"Fireweapon oluştur", "damage++"};
        maxWeaponLevel = 10;
        weaponName = "Fire Weapon";
        sprite = Resources.Load<Sprite>("images/fireball3");
    }

    public override void Upgrade()
    {
        switch (weaponLevel)
        {
            case(0):
                fireWeapon = InstantiateWeapon<FireWeapon>();
                break;
            case(1):
                fireWeapon.attackDamage += 5;
                break;
            default:
                throw new UnityException("Invalid level");
        }
    }
}
