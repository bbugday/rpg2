using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat
{
    public int currentUpgrade = 0;
    public int upgradeLimit = 5;

    public bool Upgrade()
    {
        currentUpgrade++;
        if(currentUpgrade > upgradeLimit)
        {
            currentUpgrade = upgradeLimit;
            return false;
        }
        return true;
    }
}
