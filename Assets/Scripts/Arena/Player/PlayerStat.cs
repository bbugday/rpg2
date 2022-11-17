using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat
{
    public int currentUpgrade = 0;
    public int upgradeLimit = 5;

    public int[] upgradeCosts;

    public PlayerStat(int[] costs)
    {
        upgradeCosts = costs;
    }

    public int GetCost()
    {
        return IsFull() ? -1 :  upgradeCosts[currentUpgrade];
    }

    public bool IsFull()
    {
        return currentUpgrade == upgradeLimit;
    }

    public void Upgrade()
    {
        currentUpgrade++;
    }
}
