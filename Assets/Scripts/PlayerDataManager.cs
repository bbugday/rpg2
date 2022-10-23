using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>
{
    public const int moveSpeedUpgradeLimit = 5;
    public int moveSpeedUpgrade = 0;

    public bool UpgradeMoveSpeed()
    {
        moveSpeedUpgrade++;
        if(moveSpeedUpgrade > moveSpeedUpgradeLimit)
        {
            moveSpeedUpgrade = moveSpeedUpgradeLimit;
            return false;
        }
        return true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
