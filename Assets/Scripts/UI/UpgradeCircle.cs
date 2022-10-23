using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

enum Upgrades{MoveSpeed, Damage}

public class UpgradeCircle : MonoBehaviour
{
    [SerializeField] Upgrades upgradeType;
    [SerializeField] UICircle[] circles;

    PlayerDataManager playerDataManager;

    int upgrade;

    void Awake()
    {
        playerDataManager = FindObjectOfType<PlayerDataManager>();
    }

    void Update()
    {
        upgrade = GetUpgradeCount();

        for(int i = 0; i < upgrade; i++)
            circles[i].SetProgress(1);

    }

    int GetUpgradeCount()
    {
        if(upgradeType == Upgrades.MoveSpeed)
        {
            return playerDataManager.moveSpeedUpgrade;
        }

        return 0;
    }
}
