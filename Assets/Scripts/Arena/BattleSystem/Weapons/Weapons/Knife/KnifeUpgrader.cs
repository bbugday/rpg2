using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeUpgrader : WeaponUpgrader
{
    public KnifeUpgrader(GameObject prefab, MainCharacter character) : base(prefab, character)
    {
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
