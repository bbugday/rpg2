using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>, ISavable
{
    public Dictionary<string, PlayerStat> stats;

    public override void Awake()
    {
        base.Awake();

        stats = new Dictionary<string, PlayerStat>();

        stats.Add("movespeed", new PlayerStat());
        stats.Add("health", new PlayerStat());
        stats.Add("armor", new PlayerStat());
        stats.Add("cooldown", new PlayerStat());
        stats.Add("attackspeed", new PlayerStat());
        stats.Add("attackdamage", new PlayerStat());
    }

    public bool Upgrade(string statName)
    {
        return stats[statName].Upgrade();
    }

    public int GetCurrentUpgrade(string statName)
    {
        return stats[statName].currentUpgrade;
    }

    public object CaptureState()
    {
        PlayerSaveData playerSaveData = new PlayerSaveData()
        {
            statNames = new string[stats.Count],
            currentUpgrades = new int[stats.Count]
        };

        int i = 0;
        foreach(KeyValuePair<string, PlayerStat> stat in stats)
        {
            playerSaveData.statNames[i] = stat.Key;
            playerSaveData.currentUpgrades[i] = stat.Value.currentUpgrade;    
            i++;
        }

        return playerSaveData;
    }

    public void RestoreState(object state)
    {
        PlayerSaveData playerSaveData = (PlayerSaveData)state;

        for(int i = 0; i < playerSaveData.statNames.Length; i++)
        {
            stats[playerSaveData.statNames[i]].currentUpgrade = playerSaveData.currentUpgrades[i];
        }
    }
    
    [Serializable]
    public class PlayerSaveData
    {
        public string[] statNames;
        public int[] currentUpgrades;
    }
}
