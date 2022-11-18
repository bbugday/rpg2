using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgrader : WeaponUpgrader
{
    Gun gun;

    public GunUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
        descriptions = new string[] {"Gun oluştur", "Ok sayısını arttır", "Ekstra atış", "Ok hasarını 5 arttır",
                                         "Ok sayısını arttır", "Ekstra atış", "Ok hasarını 10 arttır",
                                         "Ok sayısını arttır", "Ekstra atış", "Ok hasarını 15 arttır"};
        maxWeaponLevel = 10;
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
                gun.bulletCount++;
                break;
            case(2):
                gun.extraShoots++;
                break;
            case(3):
                gun.attackDamage += 5;
                break;
            case(4):
                gun.bulletCount++;
                break;
            case(5):
                gun.extraShoots++;
                break;
            case(6):
                gun.attackDamage += 10;
                break;
            case(7):
                gun.bulletCount++;
                break;
            case(8):
                gun.extraShoots++;
                break;
            case(9):
                gun.attackDamage += 15;
                break;
            default:
                throw new UnityException("Invalid level");
        }
        weaponLevel++;
    }
}
