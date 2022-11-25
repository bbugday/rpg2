using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeUpgrader : WeaponUpgrader
{
    KnifeThrower knifeThrower;

    public KnifeUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
        descriptions = new string[] {"Bıçak oluştur", "Bıçak sayısını arttır", "Ekstra atış", "Bıçak hasarını 20 arttır",
                                         "Bıçak sayısını arttır", "Ekstra atış", "Bıçak hasarını 25 arttır",
                                         "Bıçak sayısını arttır", "Ekstra atış", "Bıçak hasarını 30 arttır"};
        maxWeaponLevel = 10;
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
                knifeThrower.knifeCount++;
                break;
            case(2):
                knifeThrower.extraShoots++;
                break;
            case(3):
                knifeThrower.attackDamage += 20;
                break;
            case(4):
                knifeThrower.knifeCount++;
                break;
            case(5):
                knifeThrower.extraShoots++;
                break;
            case(6):
                knifeThrower.attackDamage += 25;
                break;
            case(7):
                knifeThrower.knifeCount++;
                break;
            case(8):
                knifeThrower.extraShoots++;
                break;
            case(9):
                knifeThrower.attackDamage += 30;
                break;
            default:
                throw new UnityException("Invalid level");
        }
        weaponLevel++;
    }
}
