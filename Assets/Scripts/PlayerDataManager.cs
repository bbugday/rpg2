using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataManager : Singleton<PlayerDataManager>, ISavable
{
    public Dictionary<string, PlayerStat> stats;
    public int gold = 0;

    public override void Awake()
    {
        base.Awake();

        stats = new Dictionary<string, PlayerStat>();

        stats.Add("movespeed", new PlayerStat(new int[] {100, 200, 300, 400, 500}));
        stats.Add("health", new PlayerStat(new int[] {100, 200, 300, 400, 500}));
        stats.Add("armor", new PlayerStat(new int[] {100, 200, 300, 400, 500}));
        stats.Add("cooldown", new PlayerStat(new int[] {100, 200, 300, 400, 500}));
        stats.Add("attackspeed", new PlayerStat(new int[] {100, 200, 300, 400, 500}));
        stats.Add("attackdamage", new PlayerStat(new int[] {100, 200, 300, 400, 500}));

        #if UNITY_EDITOR
            gold = 1000;
        #endif

    }

    public int GetStatUpgradeCost(string statName)
    {
        return stats[statName].GetCost();
    }

    public bool IsStatUpgradeable(string statName)
    {
        return !stats[statName].IsFull();
    }

    public void Upgrade(string statName)
    {
        stats[statName].Upgrade();
        gold -= GetStatUpgradeCost(statName);
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
            currentUpgrades = new int[stats.Count],
            currentGold = gold
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
        public int currentGold;
    }
}
